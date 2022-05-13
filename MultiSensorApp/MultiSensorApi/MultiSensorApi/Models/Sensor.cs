using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
    
namespace MultiSensorApi.Models
{
    public class Sensor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name"), BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Value"), BsonRequired]
        [BsonRepresentation(BsonType.Double)]
        public decimal SensorValue { get; set; }

        [BsonElement("measuringunit"), BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string MeasuringUnit { get; set; } = string.Empty;

        [BsonElement("timestamp")]
        [BsonRequired, BsonRepresentation(BsonType.DateTime)]
        //[BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime ReadingDate { get; set; } = DateTime.Now;

        [BsonElement("type")]
        [BsonRepresentation(BsonType.String)]
        public string Type { get; set; } = string.Empty;

        //needss serializer inn order to be able to cast into Bson element
        //[BsonExtraElements]
        //public IDictionary<string,dynamic>? CatchAll { get; set; }

    }
}
