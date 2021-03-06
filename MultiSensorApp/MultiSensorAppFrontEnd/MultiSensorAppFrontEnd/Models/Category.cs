using System.ComponentModel.DataAnnotations;

namespace MultiSensorAppFrontEnd.Models
{
    public class Category
    {
        [Key, Required]
        public int Id { get; set; }


        [Required, StringLength(45)]
        public string Type { get; set; }


        [Required]
        public DateTime CreationDate { get; set; }


        [Required]
        public DateTime UpdateTime { get; set; }


        public bool IsInactive { get; set; }
    }
}
