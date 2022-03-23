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
    public class FileMimesController : ControllerBase
    {
        private readonly DataContext _context;

        public FileMimesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FileMimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileMime>>> GetFileMimes()
        {
            return await _context.FileMimes.ToListAsync();
        }

        // GET: api/FileMimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FileMime>> GetFileMime(int id)
        {
            var fileMime = await _context.FileMimes.FindAsync(id);

            if (fileMime == null)
            {
                return NotFound();
            }

            return fileMime;
        }

        // PUT: api/FileMimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFileMime(int id, FileMime fileMime)
        {
            if (id != fileMime.FileMimeId)
            {
                return BadRequest();
            }

            _context.Entry(fileMime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileMimeExists(id))
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

        // POST: api/FileMimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FileMime>> PostFileMime(FileMime fileMime)
        {
            _context.FileMimes.Add(fileMime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFileMime", new { id = fileMime.FileMimeId }, fileMime);
        }

        // DELETE: api/FileMimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileMime(int id)
        {
            var fileMime = await _context.FileMimes.FindAsync(id);
            if (fileMime == null)
            {
                return NotFound();
            }

            _context.FileMimes.Remove(fileMime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FileMimeExists(int id)
        {
            return _context.FileMimes.Any(e => e.FileMimeId == id);
        }
    }
}
