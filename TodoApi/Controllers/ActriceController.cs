using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActriceController : ControllerBase
    {
        private readonly TodoContext _context;

        public ActriceController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Actrice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actrice>>> GetActrice()
        {
            return await _context.Actrice.ToListAsync();
        }

        // GET: api/Actrice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actrice>> GetActrice(int id)
        {
            var actrice = await _context.Actrice.FindAsync(id);

            if (actrice == null)
            {
                return NotFound();
            }

            return actrice;
        }

        // PUT: api/Actrice/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActrice(int id, Actrice actrice)
        {
            if (id != actrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(actrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActriceExists(id))
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

        // POST: api/Actrice
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Actrice>> PostActrice(Actrice actrice)
        {
            _context.Actrice.Add(actrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActrice", new { id = actrice.Id }, actrice);
        }

        // DELETE: api/Actrice/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActrice(int id)
        {
            var actrice = await _context.Actrice.FindAsync(id);
            if (actrice == null)
            {
                return NotFound();
            }

            _context.Actrice.Remove(actrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActriceExists(int id)
        {
            return _context.Actrice.Any(e => e.Id == id);
        }
    }
}
