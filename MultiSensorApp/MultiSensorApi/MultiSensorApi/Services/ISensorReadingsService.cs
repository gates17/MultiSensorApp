using MultiSensorApi.Models;

namespace MultiSensorApi.Services
{
    public interface ISensorReadingsService
    {

        Task<List<Sensor>> GetAsync();
        Task<Sensor?> GetAsync(string id);
        Task CreateAsync(Sensor newSensor);
        Task UpdateAsync(string id, Sensor updatedSensor);
        Task RemoveAsync(string id);
    }
}
