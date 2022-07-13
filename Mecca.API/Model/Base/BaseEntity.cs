using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mecca.API.Model.Base
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
    }
}
