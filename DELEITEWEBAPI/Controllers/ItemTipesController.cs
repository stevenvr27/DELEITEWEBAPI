using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DELEITEWEBAPI.Models;

namespace DELEITEWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTipesController : ControllerBase
    {
        private readonly DeleiteContext _context;

        public ItemTipesController(DeleiteContext context)
        {
            _context = context;
        }

        // GET: api/ItemTipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemTipe>>> GetItemTipes()
        {
          if (_context.ItemTipes == null)
          {
              return NotFound();
          }
            return await _context.ItemTipes.ToListAsync();
        }

        // GET: api/ItemTipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemTipe>> GetItemTipe(int id)
        {
          if (_context.ItemTipes == null)
          {
              return NotFound();
          }
            var itemTipe = await _context.ItemTipes.FindAsync(id);

            if (itemTipe == null)
            {
                return NotFound();
            }

            return itemTipe;
        }

        // PUT: api/ItemTipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemTipe(int id, ItemTipe itemTipe)
        {
            if (id != itemTipe.ItemTapeId)
            {
                return BadRequest();
            }

            _context.Entry(itemTipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTipeExists(id))
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

        // POST: api/ItemTipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemTipe>> PostItemTipe(ItemTipe itemTipe)
        {
          if (_context.ItemTipes == null)
          {
              return Problem("Entity set 'DeleiteContext.ItemTipes'  is null.");
          }
            _context.ItemTipes.Add(itemTipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemTipe", new { id = itemTipe.ItemTapeId }, itemTipe);
        }

        // DELETE: api/ItemTipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemTipe(int id)
        {
            if (_context.ItemTipes == null)
            {
                return NotFound();
            }
            var itemTipe = await _context.ItemTipes.FindAsync(id);
            if (itemTipe == null)
            {
                return NotFound();
            }

            _context.ItemTipes.Remove(itemTipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemTipeExists(int id)
        {
            return (_context.ItemTipes?.Any(e => e.ItemTapeId == id)).GetValueOrDefault();
        }
    }
}
