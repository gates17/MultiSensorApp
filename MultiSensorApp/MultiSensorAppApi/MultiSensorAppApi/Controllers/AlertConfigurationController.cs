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
    public class AlertConfigurationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlertConfigurationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AlertConfiguration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlertConfiguration>>> GetAlertConfigurations()
        {
            return await _context.AlertConfigurations.ToListAsync();
        }

        // GET: api/AlertConfiguration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlertConfiguration>> GetAlertConfiguration(int id)
        {
            var alertConfiguration = await _context.AlertConfigurations.FindAsync(id);

            if (alertConfiguration == null)
            {
                return NotFound();
            }

            return alertConfiguration;
        }


        // GET: api/GetLastAccessedAlertConfiguration
        [HttpGet("GetLastAccessedAlertConfiguration")]
        public async Task<ActionResult<IEnumerable<AlertConfiguration>>> GetLastAccessedAlertConfiguration()
        {
            return await _context.AlertConfigurations.OrderBy(x => x.LastAccess).ToListAsync();
            // fazer com que apareçam apenas os últimos 10 (por ex) e apparently será necessário sockets
        }


        [HttpGet("GetAlertConfigurationBySensorId")]
        public async Task<ActionResult<AlertConfiguration>> GetAllAlertConfigurationBySensorId(int sensorId)
        {
            try
            {
                var alertConfiguration = await _context.AlertConfigurations.FirstAsync(x => x.SensorId.Equals(sensorId));

                if (alertConfiguration == null)
                {
                    return NotFound();
                }

                return alertConfiguration;
            }
            catch (Exception ex)
            {

                throw new NotImplementedException(ex.Message);
            }
        }


        [HttpGet("GetAlertConfigurationByUserId")]
        public async Task<ActionResult<AlertConfiguration>> GetAllAlertConfigurationByUserId(int userId)
        {
            try
            {
                var alertConfiguration = await _context.AlertConfigurations.FirstAsync(x => x.UserId.Equals(userId));

                if (alertConfiguration == null)
                {
                    return NotFound();
                }

                return alertConfiguration;
            }
            catch (Exception ex)
            {

                throw new NotImplementedException(ex.Message);
            }
        }


        // PUT: api/AlertConfiguration/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlertConfiguration(int id, AlertConfiguration alertConfiguration)
        {
            if (id != alertConfiguration.AlertConfigurationId)
            {
                return BadRequest();
            }

            _context.Entry(alertConfiguration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertConfigurationExists(id))
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

        // POST: api/AlertConfiguration
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlertConfiguration>> PostAlertConfiguration(AlertConfiguration alertConfiguration)
        {
            _context.AlertConfigurations.Add(alertConfiguration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlertConfiguration", new { id = alertConfiguration.AlertConfigurationId }, alertConfiguration);
        }

        // DELETE: api/AlertConfiguration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlertConfiguration(int id)
        {
            var alertConfiguration = await _context.AlertConfigurations.FindAsync(id);
            if (alertConfiguration == null)
            {
                return NotFound();
            }

            alertConfiguration.IsInactive = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlertConfigurationExists(int id)
        {
            return _context.AlertConfigurations.Any(e => e.AlertConfigurationId == id);
        }
    }
}
