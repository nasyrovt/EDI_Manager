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
    public class FeedStatusController : ControllerBase
    {
        private readonly DataContext _context;

        public FeedStatusController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FeedStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedStatus>>> GetFeedStatus()
        {
            return await _context.FeedStatus.ToListAsync();
        }

        // GET: api/FeedStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedStatus>> GetFeedStatus(int id)
        {
            var feedStatus = await _context.FeedStatus.FindAsync(id);

            if (feedStatus == null)
            {
                return NotFound();
            }

            return feedStatus;
        }

        // PUT: api/FeedStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedStatus(int id, FeedStatus feedStatus)
        {
            if (id != feedStatus.FeedStatusId)
            {
                return BadRequest();
            }

            _context.Entry(feedStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedStatusExists(id))
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

        // POST: api/FeedStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedStatus>> PostFeedStatus(FeedStatus feedStatus)
        {
            _context.FeedStatus.Add(feedStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedStatus", new { id = feedStatus.FeedStatusId }, feedStatus);
        }

        // DELETE: api/FeedStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedStatus(int id)
        {
            var feedStatus = await _context.FeedStatus.FindAsync(id);
            if (feedStatus == null)
            {
                return NotFound();
            }

            _context.FeedStatus.Remove(feedStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedStatusExists(int id)
        {
            return _context.FeedStatus.Any(e => e.FeedStatusId == id);
        }
    }
}
