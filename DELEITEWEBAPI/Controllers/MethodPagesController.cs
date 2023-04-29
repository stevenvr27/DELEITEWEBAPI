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
    public class MethodPagesController : ControllerBase
    {
        private readonly DeleiteContext _context;

        public MethodPagesController(DeleiteContext context)
        {
            _context = context;
        }

        // GET: api/MethodPages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MethodPage>>> GetMethodPages()
        {
          if (_context.MethodPages == null)
          {
              return NotFound();
          }
            return await _context.MethodPages.ToListAsync();
        }

        // GET: api/MethodPages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MethodPage>> GetMethodPage(int id)
        {
          if (_context.MethodPages == null)
          {
              return NotFound();
          }
            var methodPage = await _context.MethodPages.FindAsync(id);

            if (methodPage == null)
            {
                return NotFound();
            }

            return methodPage;
        }

        // PUT: api/MethodPages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMethodPage(int id, MethodPage methodPage)
        {
            if (id != methodPage.MethodPageId)
            {
                return BadRequest();
            }

            _context.Entry(methodPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MethodPageExists(id))
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

        // POST: api/MethodPages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MethodPage>> PostMethodPage(MethodPage methodPage)
        {
          if (_context.MethodPages == null)
          {
              return Problem("Entity set 'DeleiteContext.MethodPages'  is null.");
          }
            _context.MethodPages.Add(methodPage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMethodPage", new { id = methodPage.MethodPageId }, methodPage);
        }

        // DELETE: api/MethodPages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMethodPage(int id)
        {
            if (_context.MethodPages == null)
            {
                return NotFound();
            }
            var methodPage = await _context.MethodPages.FindAsync(id);
            if (methodPage == null)
            {
                return NotFound();
            }

            _context.MethodPages.Remove(methodPage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MethodPageExists(int id)
        {
            return (_context.MethodPages?.Any(e => e.MethodPageId == id)).GetValueOrDefault();
        }
    }
}
