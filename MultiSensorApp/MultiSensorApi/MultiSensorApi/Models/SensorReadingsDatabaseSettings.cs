namespace MultiSensorApi.Models
{
    public class SensorReadingsDatabaseSettings :ISensorReadingsDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string SensorsDataCollectionName { get; set; } = null!;
    }
}
