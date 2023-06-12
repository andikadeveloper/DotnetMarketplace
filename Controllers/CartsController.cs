using DotnetMarketplace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetMarketplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly DbMarketplaceContext _context;

        public CartsController(DbMarketplaceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _context.Carts
                .Include(c => c.Product)
                .Include(c => c.User)
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(long id)
        {
            var cart = await _context.Carts
                .Where(c => c.Id == id)
                .Include(c => c.Product)
                .Include(c => c.User)
                .AsNoTracking()
                .SingleAsync();

            if (cart == null)
            {
                return NotFound("Cart not found");
            }

            return cart;
        }

        [HttpPost]    
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            var product = await _context.Products.FindAsync(cart.ProductId);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            var user = await _context.Users.FindAsync(cart.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCart), new { id = cart.Id}, cart);
        }
    }
}