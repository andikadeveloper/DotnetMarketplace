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
                .Include(t => t.Product)
                .Include(t => t.User)
                .AsNoTracking()
                .SingleAsync();

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(TransactionRequest request)
        {
            var product = await _context.Products.FindAsync(request.ProductId);
            var user = await _context.Users.FindAsync(request.UserId);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            if (user == null)
            {
                return NotFound("User not found");
            }

            var qty = request.Qty;
            var bill = product.Price * qty;

            var transaction = new Transaction();
            transaction.ProductId = product.Id;
            transaction.Bill = bill;
            transaction.UserId = user.Id;
            transaction.Qty = qty;

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }
    }
}