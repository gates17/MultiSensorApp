using System.ComponentModel.DataAnnotations;

namespace MultiSensorAppFrontEnd.Models
{
    public class Area
    {
        [Key, Required]
        public int Id { get; set; }


        [Required, StringLength(45)]
        public string Name { get; set; }


        [Required]
        public DateTime CreationDate { get; set; }


        [Required]
        public DateTime UpdateDate { get; set; }


        public bool IsInactive { get; set; }
    }
}
