﻿using Mecca.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mecca.API.Model
{
    [Table("users_logs")]
    public class UserLog : BaseEntity
    {
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual UserLog user_log { get; set; }
        
        [Required]
        [StringLength(255)]
        public string log { get; set; }

        [Required]
        public DateTime included { get; set; } 
    }
}
