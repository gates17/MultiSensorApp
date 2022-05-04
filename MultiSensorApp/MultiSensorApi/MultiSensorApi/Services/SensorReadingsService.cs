using MultiSensorApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MultiSensorApi.Services
{
    public class SensorReadingsService
    {

        private readonly IMongoCollection<Sensor> _sensorsCollection;

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

        public async Task<List<Sensor>> GetAsync() =>
            await _sensorsCollection.Find(_ => true).ToListAsync();

        public async Task<Sensor?> GetAsync(string id) =>
            await _sensorsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Sensor newBook) =>
            await _sensorsCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Sensor updatedBook) =>
            await _sensorsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _sensorsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
