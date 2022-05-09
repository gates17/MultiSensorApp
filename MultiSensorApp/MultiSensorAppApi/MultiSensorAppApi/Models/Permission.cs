using System.ComponentModel.DataAnnotations;

namespace MultiSensorAppApi.Models
{
    public class Permission
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }


        [Required]
        public DateTime UpdateDate { get; set; }


        public bool IsInactive { get; set; }
    }
}
