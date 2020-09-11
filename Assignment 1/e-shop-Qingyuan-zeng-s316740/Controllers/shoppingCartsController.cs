using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using e_shop_Qingyuan_zeng_s316740.Data;
using e_shop_Qingyuan_zeng_s316740.Models;

namespace e_shop_Qingyuan_zeng_s316740.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class shoppingCartsController : ControllerBase
    {
        private readonly eShopDBContext _context;

        public shoppingCartsController(eShopDBContext context)
        {
            _context = context;
        }

        // GET: api/shoppingCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<shoppingCart>>> GetshoppingCarts()
        {
            return await _context.shoppingCarts.ToListAsync();
        }

        // GET: api/shoppingCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<shoppingCart>> GetshoppingCart(int id)
        {
            var shoppingCart = await _context.shoppingCarts.FindAsync(id);

            if (shoppingCart == null)
            {
                return NotFound();
            }

            return shoppingCart;
        }

        // PUT: api/shoppingCarts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutshoppingCart(int id, shoppingCart shoppingCart)
        {
            if (id != shoppingCart.shoppingCartId)
            {
                return BadRequest();
            }

            _context.Entry(shoppingCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!shoppingCartExists(id))
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

        // POST: api/shoppingCarts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<shoppingCart>> PostshoppingCart(shoppingCart shoppingCart)
        {
            _context.shoppingCarts.Add(shoppingCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetshoppingCart", new { id = shoppingCart.shoppingCartId }, shoppingCart);
        }

        // DELETE: api/shoppingCarts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<shoppingCart>> DeleteshoppingCart(int id)
        {
            var shoppingCart = await _context.shoppingCarts.FindAsync(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            _context.shoppingCarts.Remove(shoppingCart);
            await _context.SaveChangesAsync();

            return shoppingCart;
        }

        private bool shoppingCartExists(int id)
        {
            return _context.shoppingCarts.Any(e => e.shoppingCartId == id);
        }
    }
}
