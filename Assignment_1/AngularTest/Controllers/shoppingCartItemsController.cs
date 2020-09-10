using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularTest.Data;
using AngularTest.Models;

namespace AngularTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class shoppingCartItemsController : ControllerBase
    {
        private readonly eShopDBContext _context;

        public shoppingCartItemsController(eShopDBContext context)
        {
            _context = context;
        }

        // GET: api/shoppingCartItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<shoppingCartItem>>> GetshoppingCartItems()
        {
            return await _context.shoppingCartItems.ToListAsync();
        }

        // GET: api/shoppingCartItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<shoppingCartItem>> GetshoppingCartItem(int id)
        {
            var shoppingCartItem = await _context.shoppingCartItems.FindAsync(id);

            if (shoppingCartItem == null)
            {
                return NotFound();
            }

            return shoppingCartItem;
        }

        // PUT: api/shoppingCartItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutshoppingCartItem(int id, shoppingCartItem shoppingCartItem)
        {
            if (id != shoppingCartItem.shoppingCartItemId)
            {
                return BadRequest();
            }

            _context.Entry(shoppingCartItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!shoppingCartItemExists(id))
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

        // POST: api/shoppingCartItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<shoppingCartItem>> PostshoppingCartItem(shoppingCartItem shoppingCartItem)
        {
            _context.shoppingCartItems.Add(shoppingCartItem);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetshoppingCartItem", new { id = shoppingCartItem.shoppingCartItemId }, shoppingCartItem);
        }

        // DELETE: api/shoppingCartItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<shoppingCartItem>> DeleteshoppingCartItem(int id)
        {
            var shoppingCartItem = await _context.shoppingCartItems.FindAsync(id);
            if (shoppingCartItem == null)
            {
                return NotFound();
            }

            _context.shoppingCartItems.Remove(shoppingCartItem);
            await _context.SaveChangesAsync();

            return shoppingCartItem;
        }

        private bool shoppingCartItemExists(int id)
        {
            return _context.shoppingCartItems.Any(e => e.shoppingCartItemId == id);
        }
    }
}
