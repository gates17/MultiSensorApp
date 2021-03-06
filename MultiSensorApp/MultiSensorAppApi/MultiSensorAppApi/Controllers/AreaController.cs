#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiSensorAppApi.Data;
using MultiSensorAppApi.Models;

namespace MultiSensorAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AreaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Area
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreas()
        {
            return await _context.Areas.ToListAsync();
        }

        // GET: api/Area/5
        [HttpGet("GetAreaById/{id}")]
        public async Task<ActionResult<Area>> GetAreaById(int id)
        {
            var area = await _context.Areas.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return Ok(area);
        }


        // GET: api/Area/string
        [HttpGet("GetAreaByName/{name}")]
        public async Task<ActionResult<Area>> GetAreaByName(string name)
        {
            // return uma lista where level equals AlertLevel.Level

            try
            {
                var area = await _context.Areas.FirstOrDefaultAsync(x => x.Name.Equals(name));

                if (area == null)
                {
                    return NotFound();
                }

                return Ok(area);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }


        // PUT: api/Area/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArea(int id, Area area)
        {
            if (id != area.Id)
            {
                return BadRequest();
            }

            _context.Entry(area).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
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

        // POST: api/Area
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Area>> PostArea(Area area)
        {
            try
            {
                _context.Areas.Add(area);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAreaById", new { id = area.Id }, area);
            }
            // fazermos as nossas exceções!!
            catch (BadHttpRequestException)
            {

                throw new BadHttpRequestException("e");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/Area/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            area.IsInactive = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AreaExists(int id)
        {
            return _context.Areas.Any(e => e.Id == id);
        }
    }
}
