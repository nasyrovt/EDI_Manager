#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EDI_Manager;
using EDI_Manager.Data;

namespace EDI_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public FileTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FileTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileType>>> GetFileTypes()
        {
            return await _context.FileTypes.ToListAsync();
        }

        // GET: api/FileTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FileType>> GetFileType(int id)
        {
            var fileType = await _context.FileTypes.FindAsync(id);

            if (fileType == null)
            {
                return NotFound();
            }

            return fileType;
        }

        // PUT: api/FileTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFileType(int id, FileType fileType)
        {
            if (id != fileType.FileTypeId)
            {
                return BadRequest();
            }

            _context.Entry(fileType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FileTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FileType>> PostFileType(FileType fileType)
        {
            _context.FileTypes.Add(fileType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFileType", new { id = fileType.FileTypeId }, fileType);
        }

        // DELETE: api/FileTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileType(int id)
        {
            var fileType = await _context.FileTypes.FindAsync(id);
            if (fileType == null)
            {
                return NotFound();
            }

            _context.FileTypes.Remove(fileType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FileTypeExists(int id)
        {
            return _context.FileTypes.Any(e => e.FileTypeId == id);
        }
    }
}
