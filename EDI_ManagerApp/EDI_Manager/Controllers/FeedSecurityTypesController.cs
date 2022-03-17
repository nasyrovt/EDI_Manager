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
    public class FeedSecurityTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public FeedSecurityTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FeedSecurityTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedSecurityType>>> GetFeedSecurityType()
        {
            return await _context.FeedSecurityType.ToListAsync();
        }

        // GET: api/FeedSecurityTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedSecurityType>> GetFeedSecurityType(int id)
        {
            var feedSecurityType = await _context.FeedSecurityType.FindAsync(id);

            if (feedSecurityType == null)
            {
                return NotFound();
            }

            return feedSecurityType;
        }

        // PUT: api/FeedSecurityTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedSecurityType(int id, FeedSecurityType feedSecurityType)
        {
            if (id != feedSecurityType.FeedSecurityTypeId)
            {
                return BadRequest();
            }

            _context.Entry(feedSecurityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedSecurityTypeExists(id))
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

        // POST: api/FeedSecurityTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedSecurityType>> PostFeedSecurityType(FeedSecurityType feedSecurityType)
        {
            _context.FeedSecurityType.Add(feedSecurityType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedSecurityType", new { id = feedSecurityType.FeedSecurityTypeId }, feedSecurityType);
        }

        // DELETE: api/FeedSecurityTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedSecurityType(int id)
        {
            var feedSecurityType = await _context.FeedSecurityType.FindAsync(id);
            if (feedSecurityType == null)
            {
                return NotFound();
            }

            _context.FeedSecurityType.Remove(feedSecurityType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedSecurityTypeExists(int id)
        {
            return _context.FeedSecurityType.Any(e => e.FeedSecurityTypeId == id);
        }
    }
}
