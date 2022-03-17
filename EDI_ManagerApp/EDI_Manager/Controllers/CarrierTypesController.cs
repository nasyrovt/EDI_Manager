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
    public class CarrierTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public CarrierTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CarrierTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarrierType>>> GetCarrierTypes()
        {
            return await _context.CarrierTypes.ToListAsync();
        }

        // GET: api/CarrierTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarrierType>> GetCarrierType(int id)
        {
            var carrierType = await _context.CarrierTypes.FindAsync(id);

            if (carrierType == null)
            {
                return NotFound();
            }

            return carrierType;
        }

        // PUT: api/CarrierTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrierType(int id, CarrierType carrierType)
        {
            if (id != carrierType.CarrierTypeId)
            {
                return BadRequest();
            }

            _context.Entry(carrierType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrierTypeExists(id))
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

        // POST: api/CarrierTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarrierType>> PostCarrierType(CarrierType carrierType)
        {
            _context.CarrierTypes.Add(carrierType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrierType", new { id = carrierType.CarrierTypeId }, carrierType);
        }

        // DELETE: api/CarrierTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrierType(int id)
        {
            var carrierType = await _context.CarrierTypes.FindAsync(id);
            if (carrierType == null)
            {
                return NotFound();
            }

            _context.CarrierTypes.Remove(carrierType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarrierTypeExists(int id)
        {
            return _context.CarrierTypes.Any(e => e.CarrierTypeId == id);
        }
    }
}
