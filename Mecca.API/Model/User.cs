using Mecca.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mecca.API.Model
{
    [Table("users")]
    public class User : BaseEntity
    {
        [Column("first_name")]
        [Required]
        [StringLength(50)]
        public string first_name { get; set; } = "";

        [Column("last_name")]
        [Required]
        [StringLength(100)]
        public string last_name { get; set; } = "";

        [Column("email")]
        [Required]
        [StringLength(150)]
        public string email { get; set; } = "";

        [Column("username")]
        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Column("password")]
        [StringLength(150)]
        public string password { get; set; }       
        public Role Role { get; set; }
    }
}
