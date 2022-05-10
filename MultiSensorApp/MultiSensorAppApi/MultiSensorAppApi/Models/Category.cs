using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MultiSensorAppApi.Models
{
    [Index(nameof(Type), IsUnique = true)]
    public class Category
    {
        [Key, Required]
        public int Id { get; set; }


        [Required, StringLength(45)]
        [RegularExpression(@"[A-Za-z\ ]{2,45}$",
            ErrorMessage = "The inserted type does not respect the rules!")]
        public string Type { get; set; }


        [Required]
        public DateTime CreationDate { get; set; }


        public DateTime UpdateTime { get; set; } = DateTime.Now;


        [DefaultValue("false")]
        public bool IsInactive { get; set; }
    }
}
