﻿#nullable disable
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
        [HttpGet("{id}")]
        public async Task<ActionResult<AlertLevel>> GetAlertLevel(int id)
        {
            var alertLevel = await _context.AlertLevels.FindAsync(id);

            if (alertLevel == null)
            {
                return NotFound();
            }

            return alertLevel;
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
            _context.AlertLevels.Add(alertLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlertLevel", new { id = alertLevel.Id }, alertLevel);
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

            _context.AlertLevels.Remove(alertLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlertLevelExists(int id)
        {
            return _context.AlertLevels.Any(e => e.Id == id);
        }
    }
}
