using MultiSensorApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MultiSensorApi.Services
{
    public class SensorReadingsService : ISensorReadingsService
    {

        private readonly IMongoCollection<Sensor> _sensorsCollection;

        /// <summary>
        /// MongoDB connection Initialization
        /// </summary>
        /// <param name="sensorReadingsDatabaseSettings"></param>
        public SensorReadingsService(
            IOptions<SensorReadingsDatabaseSettings> sensorReadingsDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                sensorReadingsDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                sensorReadingsDatabaseSettings.Value.DatabaseName);

            _sensorsCollection = mongoDatabase.GetCollection<Sensor>(
                sensorReadingsDatabaseSettings.Value.SensorsDataCollectionName);
        }



        /// <summary>
        /// Get all sensors from Mongo Collection
        /// </summary>
        /// <returns></returns>
        public async Task<List<Sensor>> GetAsync() =>
            await _sensorsCollection.Find(_ => true).ToListAsync();


        /// <summary>
        /// Get specific Sensor from Mongo Collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Sensor?> GetAsync(string id) =>
            await _sensorsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();


        /// <summary>
        /// Get specific Sensor Readings based on specific date from Mongo Collection
        /// </summary>
        /// <param name="date"></param>
        /// <param type="DateTime"></param>
        /// <returns></returns>
        public async Task<List<Sensor>> GetByDateAsync(DateTime date)
        {

            var result = await _sensorsCollection.FindAsync(x =>
                x.ReadingDate.CompareTo(date) >= 0 && 
                x.ReadingDate.CompareTo(date.AddDays(1)) < 0
            );
            return result.ToList();

            #region syncronous method example
            //syncronous method
            //var result = _sensorsCollection.AsQueryable().ToList().Where(x => 
            //    x.ReadingDate.Year.Equals(date.Year) && 
            //    x.ReadingDate.Month.Equals(date.Month) &&
            //    x.ReadingDate.Day.Equals(date.Day)).ToList();
            //return result;
            #endregion
        }

        /// <summary>
        /// Fetches last reading from MongoDb with given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Sensor> GetLastReadingAsync(string name)
        {
            var result = await _sensorsCollection.Find(s => s.Name.Equals(name)).ToListAsync();
            return result.OrderBy(s => s.ReadingDate).Last();
        }

        //same method as above but with List<Sensor> type
        //public async Task<List<Sensor>> GetLastReadingAsync(string name)
        //{
        //    var result = await _sensorsCollection.Find(s => s.Name.Equals(name)).ToListAsync();
        //    return result.OrderBy(s => s.ReadingDate).TakeLast(1).ToList();
        //}


        /// <summary>
        /// Fetches all readings in the given time interval
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>


        //public async Task<List<Sensor>> GetFixedIntervalAsync(DateTime startDate, DateTime endDate) =>
        //    await _sensorsCollection.FindAsync(x =>
        //        x.ReadingDate.CompareTo(startDate) >= 0 &&
        //        x.ReadingDate.CompareTo(endDate) < 0
        //    ).Result.ToListAsync();

        public async Task<List<Sensor>> GetWithDatesBetweenAsync(DateTime startDate, DateTime endDate)
        {
            var result = await _sensorsCollection.FindAsync(x =>
                x.ReadingDate.CompareTo(startDate) >= 0 &&
                x.ReadingDate.CompareTo(endDate) < 0
            );
            return result.ToList();
        }


        public async Task<List<Sensor>> GetWithValuesBetweenAsync(double minValue, double maxValue)
        {
            var result = await _sensorsCollection.FindAsync(x =>
                x.SensorValue.CompareTo(minValue) >= 0 &&
                x.ReadingDate.CompareTo(maxValue) < 0
            );
            return result.ToList();
        }
        /// <summary>
        /// Use this to Create a new document on Mongo Collection
        /// </summary>
        /// <param name="newSensor"></param>
        /// <returns></returns>
        public async Task CreateAsync(Sensor newSensor) =>
            await _sensorsCollection.InsertOneAsync(newSensor);


        /// <summary>
        /// Use this method to Update a document on Mongo Collection
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedSensor"></param>
        /// <returns></returns>
        public async Task UpdateAsync(string id, Sensor updatedSensor) =>
            await _sensorsCollection.ReplaceOneAsync(x => x.Id == id, updatedSensor);


        /// <summary>
        /// Use this method to Delete a document from Mongo Collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveAsync(string id) =>
            await _sensorsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
