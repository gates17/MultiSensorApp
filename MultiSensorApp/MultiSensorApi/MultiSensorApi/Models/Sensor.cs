using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
    
namespace MultiSensorApi.Models
{
    public class Sensor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Value")]
        public decimal SensorValue { get; set; }

    }
}
