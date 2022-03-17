#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EDI_Manager.Data;
using EDI_Manager.TableDefinitions;

namespace EDI_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedFileChangesController : ControllerBase
    {
        private readonly DataContext _context;

        public FeedFileChangesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FeedFileChanges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedFileChanges>>> GetFeedFileChanges()
        {
            return await _context.FeedFileChanges.ToListAsync();
        }

        // GET: api/FeedFileChanges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedFileChanges>> GetFeedFileChanges(int id)
        {
            var feedFileChanges = await _context.FeedFileChanges.FindAsync(id);

            if (feedFileChanges == null)
            {
                return NotFound();
            }

            return feedFileChanges;
        }

        // PUT: api/FeedFileChanges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedFileChanges(int id, FeedFileChanges feedFileChanges)
        {
            if (id != feedFileChanges.FeedFileChangesId)
            {
                return BadRequest();
            }

            _context.Entry(feedFileChanges).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedFileChangesExists(id))
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

        // POST: api/FeedFileChanges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedFileChanges>> PostFeedFileChanges(FeedFileChanges feedFileChanges)
        {
            _context.FeedFileChanges.Add(feedFileChanges);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedFileChanges", new { id = feedFileChanges.FeedFileChangesId }, feedFileChanges);
        }

        // DELETE: api/FeedFileChanges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedFileChanges(int id)
        {
            var feedFileChanges = await _context.FeedFileChanges.FindAsync(id);
            if (feedFileChanges == null)
            {
                return NotFound();
            }

            _context.FeedFileChanges.Remove(feedFileChanges);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedFileChangesExists(int id)
        {
            return _context.FeedFileChanges.Any(e => e.FeedFileChangesId == id);
        }
    }
}
