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
        /// Get specific Sensor from Mongo Collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Sensor?> GetAsync(string id, DateTime date) =>
            await _sensorsCollection.Find(x => x.Id == id && x.ReadingDate.Equals(date)).FirstOrDefaultAsync();
        /// <summary>
        /// Use this to Create a new document on Mongo Collection
        /// </summary>
        /// <param name="newBook"></param>
        /// <returns></returns>
        public async Task CreateAsync(Sensor newBook) =>
            await _sensorsCollection.InsertOneAsync(newBook);


        /// <summary>
        /// Use this method to Update a document on Mongo Collection
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedBook"></param>
        /// <returns></returns>
        public async Task UpdateAsync(string id, Sensor updatedBook) =>
            await _sensorsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);


        /// <summary>
        /// Use this method to Delete a document from Mongo Collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveAsync(string id) =>
            await _sensorsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
