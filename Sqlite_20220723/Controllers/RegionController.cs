using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sqlite_20220723.EFDbContext;

namespace Sqlite_20220723.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Region
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegion()
        {
          if (_context.Region == null)
          {
              return NotFound();
          }
            return await _context.Region.ToListAsync();
        }

        // GET: api/Region/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(int id)
        {
          if (_context.Region == null)
          {
              return NotFound();
          }
            var region = await _context.Region.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return region;
        }

        // PUT: api/Region/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(int id, Region region)
        {
            if (id != region.Id)
            {
                return BadRequest();
            }

            _context.Entry(region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
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

        // POST: api/Region
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
          if (_context.Region == null)
          {
              return Problem("Entity set 'AppDbContext.Region'  is null.");
          }
            _context.Region.Add(region);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegion", new { id = region.Id }, region);
        }

        // DELETE: api/Region/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            if (_context.Region == null)
            {
                return NotFound();
            }
            var region = await _context.Region.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            _context.Region.Remove(region);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegionExists(int id)
        {
            return (_context.Region?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
