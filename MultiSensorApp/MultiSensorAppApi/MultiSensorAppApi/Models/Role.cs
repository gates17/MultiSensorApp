using System.ComponentModel.DataAnnotations;

namespace MultiSensorAppApi.Models
{
    public class Role
    {
        [Key, Required]
        public int Id { get; set; }


        [Required, StringLength(45)]
        [RegularExpression(@"[A-Za-z\ ]{2,45}$",
            ErrorMessage = "The inserted type does not respect the rules!")]
        public string Type { get; set; }


        [StringLength(45)]
        [RegularExpression(@"[A-Za-z\ ]{2,45}$",
            ErrorMessage = "The inserted description does not respect the rules!")]
        public string Description { get; set; }


        [Required]
        public DateTime CreationDate { get; set; }


        [Required]
        public DateTime UpdateDate { get; set; }


        public bool IsInactive { get; set; }
    }
}
