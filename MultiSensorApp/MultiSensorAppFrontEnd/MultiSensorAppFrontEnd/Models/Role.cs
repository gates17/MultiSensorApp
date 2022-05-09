using System.ComponentModel.DataAnnotations;

namespace MultiSensorAppApi.Models
{
    public class Role
    {
        [Key, Required]
        public int Id { get; set; }


        [Required, StringLength(45)]
        public string Type { get; set; }


        public string Description { get; set; }


        [Required]
        public DateTime CreationDate { get; set; }


        [Required]
        public DateTime UpdateDate { get; set; }


        public bool IsInactive { get; set; }
    }
}
