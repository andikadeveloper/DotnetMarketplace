using DotnetMarketplace.Models;
using DotnetMarketplace.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetMarketplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly DbMarketplaceContext _context;

        public TransactionsController(DbMarketplaceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(long id)
        {
            var transaction = await _context.Transactions
                .Where(t => t.Id == id)
                .Include(t => t.TransactionDetails)
                .Include(t => t.User)
                .AsNoTracking()
                .SingleAsync();

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        [HttpPost("/checkout")]
        public async Task<ActionResult<Transaction>> CheckoutTransaction(CheckoutTransactionRequest request)
        {
            var carts = await _context.Carts.Where(c => request.CheckoutDetail.Any(d => d == c.Id)).ToListAsync();

            if (carts.Count < request.CheckoutDetail.Count)
            {
                return NotFound("Cart not found");
            }

            var user = await _context.Users.FindAsync(carts[0].UserId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var transaction = new Transaction();
            transaction.Bill = carts.Sum(c => c.Amount * c.Qty);
            transaction.UserId = user.Id;
            transaction.PaymentProvider = request.PaymentProvider;
            transaction.ShippingProvider = request.ShippingProvider;

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            var transactionDetails = carts.Select(cart => {
                var transactionDetail = new TransactionDetail();
                transactionDetail.Amount = cart.Amount;
                transactionDetail.ProductId = cart.ProductId;
                transactionDetail.Notes = cart.Notes;
                transactionDetail.Qty = cart.Qty;
                transactionDetail.TransactionId = transaction.Id;

                return transactionDetail;
            });
            _context.TransactionDetails.AddRange(transactionDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }
    }
}