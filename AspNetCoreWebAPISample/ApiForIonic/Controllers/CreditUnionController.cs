using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiForIonic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiForIonic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditUnionController : ControllerBase
    {
        private IonicAppDbContext _context;
        public CreditUnionController(IonicAppDbContext context)
        {
            _context = context;

            if (_context.CreditUnions.Count() == 0)
            {
                _context.CreditUnions.Add(new CreditUnion { Name = "Bank Asia" });
                _context.SaveChanges();
            }
        }

        // GET: api/CreditUnion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditUnion>>> GetCreditUnions()
        {
            return await _context.CreditUnions.ToListAsync();
        }

        // GET: api/CreditUnion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreditUnion>> GetCreditUnion(long id)
        {
            var creditUnion = await _context.CreditUnions.FindAsync(id);

            if (creditUnion == null)
            {
                return NotFound();
            }

            return creditUnion;
        }

        // POST: api/CreditUnion
        [HttpPost]
        public async Task<ActionResult<CreditUnion>> PostCreditUnion(CreditUnion item)
        {
            _context.CreditUnions.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCreditUnion), new { id = item.Id }, item);
        }

        // PUT: api/CreditUnion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreditUnion(long id, CreditUnion item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/CreditUnion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreditUnion(long id)
        {
            var creditUnion = await _context.CreditUnions.FindAsync(id);

            if (creditUnion == null)
            {
                return NotFound();
            }

            _context.CreditUnions.Remove(creditUnion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}