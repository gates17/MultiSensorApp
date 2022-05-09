using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiSensorAppApi.Models
{
    public class Alert
    {
        [Key, Required]
        public int Id { get; set; }


        public int Value { get; set; }


        [StringLength(45)]
        public string Description { get; set; }


        [Required]
        public DateTime CreationDate { get; set; }


        [Required]
        public DateTime UpdateDate { get; set; }


        public bool IsInactive { get; set; }


        [Required, ForeignKey("AlertLevel")]
        public int AlertLevelId { get; set; }


        [Required, ForeignKey("Sensor")]
        public int SensorId { get; set; }

        public Sensor? Sensor { get; set; }

        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
