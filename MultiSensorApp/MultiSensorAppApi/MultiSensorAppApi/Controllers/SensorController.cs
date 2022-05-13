#nullable disable
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class SensorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SensorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sensor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetSensors()
        {
            return await _context.Sensors.ToListAsync();
        }

        // GET: api/Sensor/5
        [HttpGet("GetSensorById/{id}")]
        public async Task<ActionResult<Sensor>> GetSensorById(int id)
        {
            var sensor = await _context.Sensors.Include(s => s.AlertLevel).Include(s => s.Category).Include(s => s.Area).FirstAsync();

            if (sensor == null)
            {
                return NotFound();
            }

            return sensor;
        }

        // GET: api/Sensor/5
        [HttpGet("GetSensorByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetSensorByCategory(int categoryId)
        {
            try
            {
                var sensor = await _context.Sensors.Where(x => x.CategoryId.Equals(categoryId)).ToListAsync();
                // var sensor = await _context.sensors.where(x => x.Categoryid.equals(categoryid)).include(x => x.category).tolistasync();


                if (sensor == null)
                {
                    return NotFound();
                }

                return Ok(sensor);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }


        // GET: api/Sensor/5
        [HttpGet("GetSensorByAlertLevel/{alertLevelId}")]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetSensorByAlertLevel(int alertLevelId)
        {
            try
            {
                var sensor = await _context.Sensors.Where(x => x.AlertLevelId.Equals(alertLevelId)).ToListAsync();
                // var sensor = await _context.sensors.where(x => x.Categoryid.equals(categoryid)).include(x => x.category).tolistasync();

                if (sensor == null)
                {
                    return NotFound();
                }

                return Ok(sensor);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        // GET: api/Sensor/5
        [HttpGet("GetSensorByArea/{areaId}")]
        public async Task<ActionResult<Sensor>> GetSensorByArea(int areaId)
        {
            try
            {
                var sensor = await _context.Sensors.FirstAsync(x => x.AreaId.Equals(areaId));

                if (sensor == null)
                {
                    return NotFound();
                }

                return Ok(sensor);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }


        // GET: Api/sensor
        [HttpGet("GetInactiveSensors")]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetInactiveSensors()
        {
            try
            {
                return await _context.Sensors.Where(x => x.IsInactive.Equals(true)).ToListAsync();

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        // PUT: api/Sensor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensor(int id, Sensor sensor)
        {
            if (id != sensor.Id)
            {
                return BadRequest();
            }

            _context.Entry(sensor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            return NoContent();
        }

        // POST: api/Sensor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sensor>> PostSensor(Sensor sensor)
        {
            try
            {
                _context.Sensors.Add(sensor);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSensorById", new { id = sensor.Id }, sensor);
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

        // DELETE: api/Sensor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensor(int id)
        {
            var sensor = await _context.Sensors.FindAsync(id);
            if (sensor == null)
            {
                return NotFound();
            }

            sensor.IsInactive = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SensorExists(int id)
        {
            return _context.Sensors.Any(e => e.Id == id);
        }
    }
}
