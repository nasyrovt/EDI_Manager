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
    public class FeedFrequenciesController : ControllerBase
    {
        private readonly DataContext _context;

        public FeedFrequenciesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FeedFrequencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedFrequency>>> GetFeedFrequency()
        {
            return await _context.FeedFrequency.ToListAsync();
        }

        // GET: api/FeedFrequencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedFrequency>> GetFeedFrequency(int id)
        {
            var feedFrequency = await _context.FeedFrequency.FindAsync(id);

            if (feedFrequency == null)
            {
                return NotFound();
            }

            return feedFrequency;
        }

        // PUT: api/FeedFrequencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedFrequency(int id, FeedFrequency feedFrequency)
        {
            if (id != feedFrequency.FeedFrequencyId)
            {
                return BadRequest();
            }

            _context.Entry(feedFrequency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedFrequencyExists(id))
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

        // POST: api/FeedFrequencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedFrequency>> PostFeedFrequency(FeedFrequency feedFrequency)
        {
            _context.FeedFrequency.Add(feedFrequency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedFrequency", new { id = feedFrequency.FeedFrequencyId }, feedFrequency);
        }

        // DELETE: api/FeedFrequencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedFrequency(int id)
        {
            var feedFrequency = await _context.FeedFrequency.FindAsync(id);
            if (feedFrequency == null)
            {
                return NotFound();
            }

            _context.FeedFrequency.Remove(feedFrequency);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedFrequencyExists(int id)
        {
            return _context.FeedFrequency.Any(e => e.FeedFrequencyId == id);
        }
    }
}
