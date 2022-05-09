using System.ComponentModel.DataAnnotations;

namespace MultiSensorAppApi.Models
{
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


        [Required]
        public DateTime UpdateDate { get; set; }


        public bool IsInactive { get; set; }
    }
}
