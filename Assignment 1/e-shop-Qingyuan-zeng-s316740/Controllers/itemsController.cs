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
    public class itemsController : ControllerBase
    {
        private readonly eShopDBContext _context;

        public itemsController(eShopDBContext context)
        {
            _context = context;
        }

        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<item>>> Getitems()
        {
            return await _context.items.ToListAsync();
        }

        // GET: api/items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<item>> Getitem(int id)
        {
            var item = await _context.items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/items/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putitem(int id, item item)
        {
            if (id != item.itemId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemExists(id))
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

        // POST: api/items
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<item>> Postitem(item item)
        {
            _context.items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getitem", new { id = item.itemId }, item);
        }

        // DELETE: api/items/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<item>> Deleteitem(int id)
        {
            var item = await _context.items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.items.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }

        private bool itemExists(int id)
        {
            return _context.items.Any(e => e.itemId == id);
        }
    }
}
