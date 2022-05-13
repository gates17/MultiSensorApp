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
    public class AlertController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlertController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Alert
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alert>>> GetAlerts()
        {
            return await _context.Alerts.ToListAsync();
        }

        // GET: api/Alert/5
        [HttpGet("GetAlertById/{id}")]
        public async Task<ActionResult<Alert>> GetAlertById(int id)
        {
            var alert = await _context.Alerts.Include(a => a.User).Include(a => a.Sensor).FirstAsync(a => a.Id.Equals(id));

            if (alert == null)
            {
                return NotFound();
            }

            return Ok(alert);
        }


        [HttpGet("GetAlertBySensorId/{sensorId}")]
        public async Task<ActionResult<IEnumerable<Alert>>> GetAlertBySensorId(int sensorId)
        {
            try
            {
                var alert = await _context.Alerts.Where(x => x.SensorId.Equals(sensorId)).ToListAsync();

                if (alert == null)
                {
                    return NotFound();
                }

                return Ok(alert);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }


        [HttpGet("GetAlertByUserId/{userId}")]
        public async Task<ActionResult<IEnumerable<Alert>>> GetAlertByUserId(int userId)
        {
            try
            {
                var alert = await _context.Alerts.Where(x => x.UserId.Equals(userId)).ToListAsync();

                if (alert == null)
                {
                    return NotFound();
                }

                return Ok(alert);
            }
            catch (Exception ex)
            {

                throw new NotImplementedException(ex.Message);
            }
        }

        // PUT: api/Alert/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlert(int id, Alert alert)
        {
            if (id != alert.Id)
            {
                return BadRequest();
            }

            _context.Entry(alert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertExists(id))
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

        // POST: api/Alert
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alert>> PostAlert(Alert alert)
        {
            try
            {
                _context.Alerts.Add(alert);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAlertById", new { id = alert.Id }, alert);

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

        // DELETE: api/Alert/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlert(int id)
        {
            var alert = await _context.Alerts.FindAsync(id);
            if (alert == null)
            {
                return NotFound();
            }

            alert.IsInactive = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlertExists(int id)
        {
            return _context.Alerts.Any(e => e.Id == id);
        }
    }
}
