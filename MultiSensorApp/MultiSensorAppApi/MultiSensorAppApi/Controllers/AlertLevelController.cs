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
    public class AlertLevelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlertLevelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AlertLevel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlertLevel>>> GetAlertLevels()
        {
            return await _context.AlertLevels.ToListAsync();
        }

        // GET: api/AlertLevel/5
        [HttpGet("GetAlertLevelById/{id}")]
        public async Task<ActionResult<AlertLevel>> GetAlertLevelById(int id)
        {
            var alertLevel = await _context.AlertLevels.FindAsync(id);

            if (alertLevel == null)
            {
                return NotFound();
            }

            return Ok(alertLevel);
        }

        // PUT: api/AlertLevel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlertLevel(int id, AlertLevel alertLevel)
        {
            if (id != alertLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(alertLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertLevelExists(id))
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

        // POST: api/AlertLevel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlertLevel>> PostAlertLevel(AlertLevel alertLevel)
        {
            try
            {
                _context.AlertLevels.Add(alertLevel);
                await _context.SaveChangesAsync();

                return CreatedAtAction("AlertLevelById", new { id = alertLevel.Id }, alertLevel);
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

        // DELETE: api/AlertLevel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlertLevel(int id)
        {
            var alertLevel = await _context.AlertLevels.FindAsync(id);
            if (alertLevel == null)
            {
                return NotFound();
            }

            alertLevel.IsInactive = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlertLevelExists(int id)
        {
            return _context.AlertLevels.Any(e => e.Id == id);
        }
    }
}
