namespace MultiSensorApi.Models
{
    public interface ISensorReadingsDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; } 
        string SensorsDataCollectionName { get; set; }
    }
}
