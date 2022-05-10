using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiSensorAppApi.Models
{
    public class Profile
    {
        [Key, Required]
        public int Id { get; set; }


        [Required]
        public DateTime CreationDate { get; set; }


        public DateTime UpdateDate { get; set; } = DateTime.Now;


        [DefaultValue(false)]
        public bool IsInactive { get; set; }


        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }


        [Required, ForeignKey("Area")]
        public int AreaId { get; set; }

        public Area? Area { get; set; }



        [Required, ForeignKey("Role")]
        public int RoleId { get; set; }

        public Role? Role { get; set; }


        [Required, ForeignKey("Permission")]
        public int PermissionId { get; set; }

        public Permission? Permission { get; set; }
        
    }
}
