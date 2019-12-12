using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiForIonic.Models;
using ApiForIonic.ViewModels;

namespace ApiForIonic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentHistoriesController : ControllerBase
    {
        private readonly IonicAppDbContext _context;

        public PaymentHistoriesController(IonicAppDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentHistoryViewModel>>> GetPaymentHistories()
        {
            var paymentHistories =  await _context.PaymentHistories.Include(c=>c.CreditUnion).ToListAsync();
            var paymentHistoryViewModels = new List<PaymentHistoryViewModel>();
            if(paymentHistories!=null && paymentHistories.Any())
            {
                paymentHistories.ForEach(c =>
                {
                    PaymentHistoryViewModel viewModel = new PaymentHistoryViewModel
                    {
                        CreditUnionId = c.CreditUnionId,
                        PayeeName = c.CreditUnion.Name,
                        Amount = c.Amount,
                        Id = c.Id
                    };
                    paymentHistoryViewModels.Add(viewModel);
                });
            }
            return paymentHistoryViewModels;
        }

        // GET: api/PaymentHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentHistory>> GetPaymentHistory(Guid id)
        {
            var paymentHistory = await _context.PaymentHistories.FindAsync(id);

            if (paymentHistory == null)
            {
                return NotFound();
            }

            return paymentHistory;
        }

        // PUT: api/PaymentHistories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentHistory(Guid id, PaymentHistory paymentHistory)
        {
            if (id != paymentHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentHistoryExists(id))
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

        // POST: api/PaymentHistories
        [HttpPost]
        public async Task<ActionResult<PaymentHistory>> PostPaymentHistory(PaymentHistory paymentHistory)
        {
            paymentHistory.PaymentMadeOn = DateTime.Now;
            paymentHistory.Id = Guid.NewGuid();
            _context.PaymentHistories.Add(paymentHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentHistory", new { id = paymentHistory.Id }, paymentHistory);
        }

        // DELETE: api/PaymentHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentHistory>> DeletePaymentHistory(Guid id)
        {
            var paymentHistory = await _context.PaymentHistories.FindAsync(id);
            if (paymentHistory == null)
            {
                return NotFound();
            }

            _context.PaymentHistories.Remove(paymentHistory);
            await _context.SaveChangesAsync();

            return paymentHistory;
        }

        private bool PaymentHistoryExists(Guid id)
        {
            return _context.PaymentHistories.Any(e => e.Id == id);
        }
    }
}
