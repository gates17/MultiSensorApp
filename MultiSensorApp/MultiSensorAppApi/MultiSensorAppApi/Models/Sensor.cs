using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiSensorAppApi.Models
{
    // name is unique to not allow ambiguity between sensors that measure the same parameters 
    // (having two humidity sensors may make it hard finding out which values are coming from which sensor, for example)
    [Microsoft.EntityFrameworkCore.Index(nameof(Name), IsUnique = true)]
    public class Sensor
    {
        [Key, Required]
        public int Id { get; set; }


        [Required, StringLength(45)]
        public string Name { get; set; }


        [StringLength(45)]
        [RegularExpression(@"[A-Za-z\ ]{2,45}$",
            ErrorMessage = "The inserted description does not respect the rules!")]
        public string Description { get; set; }


        [Required]
        public DateTime CreationDate { get; set; }


        public DateTime UpdateDate { get; set; } = DateTime.Now;


        [DefaultValue(false)]
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
