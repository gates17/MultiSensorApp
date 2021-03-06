using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiSensorAppFrontEnd.Models
{
    public class Sensor
    {
        [Key, Required]
        public int Id { get; set; }


        [Required, StringLength(45)]
        public string Name { get; set; }


        public string Description { get; set; }


        [Required]
        public DateTime CreationDate { get; set; }


        [Required]
        public DateTime UpdateDate { get; set; }


        public bool IsInactive { get; set; }


        [Required, ForeignKey("AlertLevel")]
        public int AlertLevelId { get; set; }

        public AlertLevel? AlertLevel { get; set; }


        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }


        [Required, ForeignKey("Area")]
        public int AreaId { get; set; }

        public Area? Area { get; set; }
    }
}
