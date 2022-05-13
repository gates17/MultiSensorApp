using Microsoft.AspNetCore.Mvc;
using MultiSensorApi.Models;
using MultiSensorApi.Services;
using System.Net;
using MultiSensorApi.Helpers;

namespace MultiSensorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly SensorReadingsService _sensorReadingsService;

        public SensorController(SensorReadingsService sensorReadingsService) =>
            _sensorReadingsService = sensorReadingsService;


        /// <summary>
        /// Returns a List of all Sensor readingss
        /// </summary>
        /// <returns>List<Sensor></returns>
        [HttpGet]
        public async Task<List<Sensor>> Get() =>
            await _sensorReadingsService.GetAsync();


        /// <summary>
        /// Returns a Sensor reading with the specified ObjectId. ObjectId must have 24 characters 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sensor</returns>
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


        /// <summary>
        /// Returns all Sensor readings given a specifc Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>List<Sensor></returns>
        [HttpGet("GetByDate/{date}")]
        public async Task<ActionResult<List<Sensor>>> GetByDate(string date)
        {
            var decodedDate = WebUtility.UrlDecode(date);
            DateTime dateOnly = Convert.ToDateTime(decodedDate);
            var sensor = await _sensorReadingsService.GetByDateAsync(dateOnly);
            //cast to DateOnly
            //var sensor = await _sensorReadingsService.GetByDateAsync(DateOnly.FromDateTime(dateOnly));
        
            if (sensor is null)
            {
                return NotFound();
            }

            return sensor;
        }

        /// <summary>
        /// Returns all Sensor readings in a given interval between a starting date and an ending date with timespans.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("GetBetweenFullDates")]
        public async Task<ActionResult<List<Sensor>>> GetBetweenFullDates(string startDate, string startTime, string endDate, string endTime)
        {
            DateTime startTimestamp;
            DateTime endTimestamp;

            startTimestamp = Validations.StringToDateTime(WebUtility.UrlDecode(startDate), WebUtility.UrlDecode(startTime));
            endTimestamp = (DateTime)Validations.StringToDateTime(WebUtility.UrlDecode(endDate), WebUtility.UrlDecode(endTime));

            if (startTimestamp > endTimestamp)
                return BadRequest();

            var result = await _sensorReadingsService.GetWithDatesBetweenAsync(startTimestamp, endTimestamp);
            if (result.Equals(null))
            {
                return NotFound();
            }
            return result;
        }


        [HttpGet("GetBetweenDates")]
        public async Task<ActionResult<List<Sensor>>> GetBetweenDates(string startDate, string endDate)
        {
            DateTime startTimestamp;
            DateTime endTimestamp;

            startTimestamp = Validations.StringToDateTime(WebUtility.UrlDecode(startDate));
            endTimestamp = (DateTime)Validations.StringToDateTime(WebUtility.UrlDecode(endDate));

            if (startTimestamp > endTimestamp)
                return BadRequest();

            var result = await _sensorReadingsService.GetWithDatesBetweenAsync(startTimestamp, endTimestamp);
            if (result.Equals(null))
            {
                return NotFound();
            }
            return result;
        }

       
        [HttpGet("GetBetweenTimeSpans")]
        public async Task<ActionResult<List<Sensor>>> GetBetweenTimeSpans(string startTime, string endTime)
        {
            DateTime startTimestamp;
            DateTime endTimestamp;

            startTimestamp = Validations.StringToTime(WebUtility.UrlDecode(startTime));
            endTimestamp = (DateTime)Validations.StringToTime(WebUtility.UrlDecode(endTime));

            if (startTimestamp > endTimestamp)
                return BadRequest();

            var result = await _sensorReadingsService.GetWithDatesBetweenAsync(startTimestamp, endTimestamp);
            if (result.Equals(null))
            {
                return NotFound();
            }
            return result;
        }
       


        [HttpGet("GetBetweenValues")]
        public async Task<ActionResult<List<Sensor>>> GetBetweenValues(double? minValue, double maxValue)
        {
            if (minValue.Equals(null))
            {
                minValue = 0;
            }

            var result = await _sensorReadingsService.GetWithValuesBetweenAsync(minValue.Value, maxValue);
            if (result.Equals(null))
            {
                return NotFound();
            }
            return result;
        }



        //public async Task<ActionResult<List<Sensor>>> GetAllReadingsWithNameTypeBetweenDatesAndBetweenValues()
        //{
        //    return NotFound();
        //}



        /// <summary>
        /// Returns last reading of a sensor with a given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List<Sensor</returns>
        [HttpGet("GetLastReading/{name}")]
        public async Task<Sensor> GetLastReading(string name) =>
            await _sensorReadingsService.GetLastReadingAsync(name);



        /// <summary>
        /// Creates a new Sensor reading
        /// </summary>
        /// <param name="newSensor"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Sensor newSensor)
        {
            await _sensorReadingsService.CreateAsync(newSensor);

            return CreatedAtAction(nameof(Get), new { id = newSensor.Id }, newSensor);
        }


        /// <summary>
        /// Updates current Sensor reading given ObjectId with 24 characters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedSensor"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Removes current Sensor reading given ObjectId with 24 characters
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
