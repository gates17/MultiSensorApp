using Microsoft.AspNetCore.Mvc;
using MultiSensorApi.Models;
using MultiSensorApi.Services;

namespace MultiSensorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly SensorReadingsService _sensorReadingsService;

        public SensorController(SensorReadingsService sensorReadingsService) =>
            _sensorReadingsService = sensorReadingsService;

        [HttpGet]
        public async Task<List<Sensor>> Get() =>
            await _sensorReadingsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Sensor>> Get(string id)
        {
            var sensor = await _sensorReadingsService.GetAsync(id);

            if (sensor is null)
            {
                return NotFound();
            }

            return sensor;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Sensor>> Get(string id, DateTime date)
        {

            date = DateTime.Now;
            var sensor = await _sensorReadingsService.GetAsync(id, date);

            if (sensor is null)
            {
                return NotFound();
            }

            return sensor;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Sensor newSensor)
        {
            await _sensorReadingsService.CreateAsync(newSensor);

            return CreatedAtAction(nameof(Get), new { id = newSensor.Id }, newSensor);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Sensor updatedSensor)
        {
            var sensor = await _sensorReadingsService.GetAsync(id);

            if (sensor is null)
            {
                return NotFound();
            }

            updatedSensor.Id = sensor.Id;

            await _sensorReadingsService.UpdateAsync(id, updatedSensor);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var sensor = await _sensorReadingsService.GetAsync(id);

            if (sensor is null)
            {
                return NotFound();
            }

            await _sensorReadingsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
