using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectK3.Entities;

namespace ProjectK3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CartController : ControllerBase
    {
        private ProjectK3Context _cart;

        public CartController(ProjectK3Context cart)
        {
            _cart = cart;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _cart.Carts.ToListAsync();
        }

        // GET: api/Cart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            var cart = await _cart.Carts.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // POST: api/Cart
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            _cart.Carts.Add(cart);
            await _cart.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.CartId }, cart);
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _cart.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _cart.Carts.Remove(cart);
            await _cart.SaveChangesAsync();

            return NoContent();
        }
    }

}

