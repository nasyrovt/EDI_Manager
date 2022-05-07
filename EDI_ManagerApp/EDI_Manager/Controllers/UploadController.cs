using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using EDI_Manager.TableDefinitions;
using EDI_Manager.Data;
using System.Reflection;
using EDI_Manager.Utilities;
using Microsoft.EntityFrameworkCore;

namespace EDI_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {

        private readonly DataContext _context;

        public UploadController(DataContext context)
        {
            _context = context;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Ressources", "Files");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    await UploadFileInfo(dbPath);

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        private async Task UploadFileInfo(string path)
        { 
            using var streamReader = new StreamReader(path);
            
            using var csvReeader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            csvReeader.Context.RegisterClassMap<RecordClassMap>();

            var records = csvReeader.GetRecords<Record>();

            foreach (var record in records)
            {
                if (record.RecordType == "Employee")
                {
                    int employeeId = EmployeeCreateUpdate(path, record);

                    ElectionCreateUpdate(path, record, employeeId, "E");

                }
                else if (record.Relationship == "Spouse")
                {
                    int spouseId = SpouseCreeateUpdate(path, record);

                    ElectionCreateUpdate(path, record, spouseId, "S");

                }
                else if (record.Relationship == "Child")
                {
                    int childId = ChildCreateUpdate(path, record);

                    ElectionCreateUpdate(path, record, childId, "C");
                }
            }
            await _context.SaveChangesAsync();
        }

        private int ChildCreateUpdate(string path, Record record)
        {
            int childId = -1;
            PropertyInfo[] childProperties = typeof(Child).GetProperties();
            Child child = new();

            foreach (var property in childProperties)
            {
                if (property.Name == "ChildId" || property.Name == "SourceFilePath") continue;
                property.SetValue(child, value: record.GetType().GetProperty(property.Name).GetValue(record));

            }

            child.SourceFilePath = path;


            childId = (from children in _context.Children.AsNoTracking()
                       where children.SourceFilePath == path && children.Ssn == child.Ssn
                       && children.MemberFirstName == child.MemberFirstName && children.MemberLastName == child.MemberLastName
                       && children.MemberBirthDate == child.MemberBirthDate
                       select children.ChildId).FirstOrDefault();


            if (childId == 0)
            {
                _context.Children.Add(child);
                childId = _context.Children.OrderByDescending(ch => ch.ChildId).FirstOrDefault().ChildId;
            }
            else
            {
                child.ChildId = childId;
                _context.Entry(child).State = EntityState.Modified;
            }

            return childId;
        }

        private int SpouseCreeateUpdate(string path, Record record)
        {
            int spouseId = -1;
            PropertyInfo[] spouseProperties = typeof(Spouse).GetProperties();
            Spouse spouse = new();
            foreach (var property in spouseProperties)
            {
                if (property.Name == "SpouseId" || property.Name == "SourceFilePath") continue;
                property.SetValue(spouse, value: record.GetType().GetProperty(property.Name).GetValue(record));
            }

            spouse.SourceFilePath = path;


            spouseId = (from spouses in _context.Spouses.AsNoTracking()
                        where spouses.SourceFilePath == path && spouses.Ssn == spouse.Ssn
                        select spouses.SpouseId).FirstOrDefault();


            if (spouseId == 0)
            {
                _context.Spouses.Add(spouse);
                spouseId = _context.Spouses.OrderByDescending(sp => sp.SpouseId).FirstOrDefault().SpouseId;
            }
            else
            {
                spouse.SpouseId = spouseId;
                _context.Entry(spouse).State = EntityState.Modified;
            }

            return spouseId;
        }

        private int EmployeeCreateUpdate(string path, Record record)
        {
            int employeeId = -1;
            Employee employee = new();
            PropertyInfo[] personProperties = typeof(Person).GetProperties();
            foreach (var property in personProperties)
            {
                if (property.Name == "Id" || property.Name == "SourceFilePath") continue;
                property.SetValue(employee, value: record.GetType().GetProperty(property.Name).GetValue(record));
            }

            employee.SourceFilePath = path;

            employeeId = (from employees in _context.Employees.AsNoTracking()
                          where (employees.SourceFilePath == path && employees.Ssn == employee.Ssn)
                          select employees.EmployeeId).FirstOrDefault();

            if (employeeId == 0)
            {
                _context.Employees.Add(employee);
                employeeId = _context.Employees.OrderByDescending(empl => empl.EmployeeId).FirstOrDefault().EmployeeId;
            }
            else
            {
                employee.EmployeeId = employeeId;
                _context.Entry(employee).State = EntityState.Modified;
            }

            return employeeId;
        }

        private void ElectionCreateUpdate(string path, Record record, int employeeId, string personType)
        {
            PropertyInfo[] electionProperties = typeof(Election).GetProperties();
            Election personElection = new();
            string electionId;

            foreach (var property in electionProperties)
            {
                if (property.Name == "ElectionId" || property.Name == "SourceFilePath") continue;
                property.SetValue(personElection, value: record.GetType().GetProperty(property.Name).GetValue(record));
            }

            personElection.ElectionId = personType + employeeId;
            personElection.SourceFilePath = path;

            try
            {
                electionId = (from elections in _context.Elections.AsNoTracking()
                              where elections.ElectionId == personElection.ElectionId
                              select elections.ElectionId).Single();
            }
            catch (Exception e)
            {
                electionId = "";
            }

            if (electionId == "")
            {
                _context.Elections.Add(personElection);
            }
            else
            {
                _context.Entry(personElection).State = EntityState.Modified;
            }
        }
        /*
        #region HttpPosts


        [HttpPost]
        [Route("spouse")]
        public async Task PostSpouse(Spouse spouse)
        {
            _context.Spouses.Add(spouse);
            //await _context.SaveChangesAsync();
        }

        [HttpPost]
        [Route("child")]
        public async Task PostChild(Child child)
        {
            _context.Children.Add(child);
            //await _context.SaveChangesAsync();
        }

        [HttpPost]
        [Route("employee")]
        public async Task PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            //await _context.SaveChangesAsync();
        }

        [HttpPost]
        [Route("election")]
        public async Task PostElection(Election election)
        {
            _context.Elections.Add(election);
            //await _context.SaveChangesAsync();
        }


        #endregion


        #region HttpPuts

        [HttpPut("employee/{id}")]
        public async Task PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return;
            }

            _context.Entry(employee).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }

        [HttpPut("spouse/{id}")]
        public async Task PutSpouse(int id, Spouse spouse)
        {
            if (id != spouse.SpouseId)
            {
                return;
            }
            _context.Entry(spouse).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            
        }

        [HttpPut("child/{id}")]
        public async Task PutChild(int id, Child child)
        {
            if (id != child.ChildId)
            {
                return;
            }

            _context.Entry(child).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }

        [HttpPut("election/{id}")]
        public async Task PutElection(string id, Election election)
        {
            if (id != election.ElectionId)
            {
                return;
            }

            _context.Entry(election).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }

        #endregion


        #region ExistsBooleans

        private bool EmployeeExists(int id)
        {
            return _context.Employees.AsNoTracking().Any(e => e.EmployeeId == id);
        }

        private bool SpouseExists(int id)
        {
            return _context.Spouses.AsNoTracking().Any(e => e.SpouseId == id);
        }

        private bool ChildExists(int id)
        {
            return _context.Children.AsNoTracking().Any(e => e.ChildId == id);
        }

        private bool ElectionExists(string id)
        {
            return _context.Elections.AsNoTracking().Any(e => e.ElectionId == id);
        }

        #endregion
        */
    }
}

