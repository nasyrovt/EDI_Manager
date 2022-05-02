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
        public IActionResult Upload()
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

                    UploadFileInfo(file, dbPath);

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

        private async void UploadFileInfo(IFormFile file, string path)
        {
            using var streamReader = new StreamReader(path);

            using var csvReeader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            csvReeader.Context.RegisterClassMap<RecordClassMap>();
            var records = csvReeader.GetRecords<Record>();

            PropertyInfo[] propertiesEmployee = typeof(Employee).GetProperties();
            PropertyInfo[] propertiesSpouse = typeof(Spouse).GetProperties();
            PropertyInfo[] propertiesChild = typeof(Child).GetProperties();

            foreach (var record in records)
            {
                if (record.RecordType == "Employee")
                {
                    Employee employee = new();
                    foreach (var property in propertiesEmployee)
                    {
                        property.SetValue(employee, value: record.GetType().GetProperty(property.Name).GetValue(record));
                    }
                    if (employee != null)
                        await PostEmployee(employee);
                }
                else if (record.Relationship == "Spouse")
                {
                    Spouse spouse = new();
                    foreach (var property in propertiesSpouse)
                    {
                        property.SetValue(spouse, value: record.GetType().GetProperty(property.Name).GetValue(record));
                    }
                    if (spouse != null)
                        await PostSpouse(spouse);
                }
                else if (record.Relationship == "Child")
                {
                    Child child = new();
                    foreach (var property in propertiesChild)
                    {
                        property.SetValue(child, value: record.GetType().GetProperty(property.Name).GetValue(record));
                    }
                    if (child != null)
                        await PostChild(child);
                }
            }
        }

        [HttpPost]
        [Route("spouse")]
        public async Task PostSpouse(Spouse spouse)
        {
            _context.Spouses.Add(spouse);
            await _context.SaveChangesAsync();
        }

        [HttpPost]
        [Route("child")]
        public async Task PostChild(Child child)
        {
            _context.Children.Add(child);
            await _context.SaveChangesAsync();
        }

        [HttpPost]
        [Route("employee")]
        public async Task PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
    }
}