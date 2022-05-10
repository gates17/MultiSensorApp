using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MultiSensorAppApi.Models
{
    public class Permission
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }


        public DateTime UpdateDate { get; set; } = DateTime.Now;


        [DefaultValue(false)]
        public bool IsInactive { get; set; }
    }
}
