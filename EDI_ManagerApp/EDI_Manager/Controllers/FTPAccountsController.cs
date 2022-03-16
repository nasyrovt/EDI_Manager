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
    public class FTPAccountsController : ControllerBase
    {
        private readonly DataContext _context;

        public FTPAccountsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FTPAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FTPAccount>>> GetFTPAccounts()
        {
            return await _context.FTPAccounts.ToListAsync();
        }

        // GET: api/FTPAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FTPAccount>> GetFTPAccount(int id)
        {
            var fTPAccount = await _context.FTPAccounts.FindAsync(id);

            if (fTPAccount == null)
            {
                return NotFound();
            }

            return fTPAccount;
        }

        // PUT: api/FTPAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFTPAccount(int id, FTPAccount fTPAccount)
        {
            if (id != fTPAccount.FTPAccountId)
            {
                return BadRequest();
            }

            _context.Entry(fTPAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FTPAccountExists(id))
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

        // POST: api/FTPAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FTPAccount>> PostFTPAccount(FTPAccount fTPAccount)
        {
            _context.FTPAccounts.Add(fTPAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFTPAccount", new { id = fTPAccount.FTPAccountId }, fTPAccount);
        }

        // DELETE: api/FTPAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFTPAccount(int id)
        {
            var fTPAccount = await _context.FTPAccounts.FindAsync(id);
            if (fTPAccount == null)
            {
                return NotFound();
            }

            _context.FTPAccounts.Remove(fTPAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FTPAccountExists(int id)
        {
            return _context.FTPAccounts.Any(e => e.FTPAccountId == id);
        }
    }
}
