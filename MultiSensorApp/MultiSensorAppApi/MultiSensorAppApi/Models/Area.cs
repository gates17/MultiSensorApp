using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MultiSensorAppApi.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Area
    {
        [Key, Required]
        public int Id { get; set; }


        [Required, StringLength(45)]
        [RegularExpression(@"[A-Za-z\ ]{2,45}$",
            ErrorMessage = "The inserted name does not respect the rules!")]
        public string Name { get; set; }


        [Required]
        public DateTime CreationDate { get; set; }


        public DateTime UpdateDate { get; set; } = DateTime.Now;


        [DefaultValue(false)]
        public bool IsInactive { get; set; } = false;
    }
}
