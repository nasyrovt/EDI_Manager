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
using Microsoft.AspNetCore.Authorization;

namespace EDI_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class SSHKeysController : ControllerBase
    {
        private readonly DataContext _context;

        public SSHKeysController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SSHKeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SSHKey>>> GetSSHKeys()
        {
            return await _context.SSHKeys.ToListAsync();
        }

        // GET: api/SSHKeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SSHKey>> GetSSHKey(int id)
        {
            var sSHKey = await _context.SSHKeys.FindAsync(id);

            if (sSHKey == null)
            {
                return NotFound();
            }

            return sSHKey;
        }

        // PUT: api/SSHKeys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSSHKey(int id, SSHKey sSHKey)
        {
            if (id != sSHKey.SSHKeyId)
            {
                return BadRequest();
            }

            _context.Entry(sSHKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SSHKeyExists(id))
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

        // POST: api/SSHKeys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SSHKey>> PostSSHKey(SSHKey sSHKey)
        {
            _context.SSHKeys.Add(sSHKey);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSSHKey", new { id = sSHKey.SSHKeyId }, sSHKey);
        }

        // DELETE: api/SSHKeys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSSHKey(int id)
        {
            var sSHKey = await _context.SSHKeys.FindAsync(id);
            if (sSHKey == null)
            {
                return NotFound();
            }

            _context.SSHKeys.Remove(sSHKey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SSHKeyExists(int id)
        {
            return _context.SSHKeys.Any(e => e.SSHKeyId == id);
        }
    }
}
