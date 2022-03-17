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
    public class CarriersController : ControllerBase
    {
        private readonly DataContext _context;

        public CarriersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Carriers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrier>>> GetCarriers()
        {
            return await _context.Carriers.ToListAsync();
        }

        // GET: api/Carriers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrier>> GetCarrier(int id)
        {
            var carrier = await _context.Carriers.FindAsync(id);

            if (carrier == null)
            {
                return NotFound();
            }

            return carrier;
        }

        // PUT: api/Carriers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrier(int id, Carrier carrier)
        {
            if (id != carrier.CarrierId)
            {
                return BadRequest();
            }

            _context.Entry(carrier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrierExists(id))
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

        // POST: api/Carriers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carrier>> PostCarrier(Carrier carrier)
        {
            _context.Carriers.Add(carrier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrier", new { id = carrier.CarrierId }, carrier);
        }

        // DELETE: api/Carriers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrier(int id)
        {
            var carrier = await _context.Carriers.FindAsync(id);
            if (carrier == null)
            {
                return NotFound();
            }

            _context.Carriers.Remove(carrier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarrierExists(int id)
        {
            return _context.Carriers.Any(e => e.CarrierId == id);
        }
    }
}
