using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiSensorAppApi.Models
{
    public class AlertConfiguration
    {
        [Key, Required]
        public int AlertConfigurationId { get; set; }


        public string Favorites { get; set; }


        [Required]
        public DateTime LastAcsess { get; set; }


        public int Max { get; set; }


        public int Min { get; set; }


        [Required]
        public DateTime CreationDate { get; set; }


        public DateTime UpdateDate { get; set; } = DateTime.Now;


        [DefaultValue(false)]
        public bool IsInactive { get; set; }


        [Required, ForeignKey("Sensor")]
        public int SensorId { get; set; }

        public Sensor? Sensor { get; set; }


        [Required, ForeignKey("User")]
        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
