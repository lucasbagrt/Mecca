using System.ComponentModel.DataAnnotations;

namespace Mecca.API.Model.RequestResponse.Users
{
    public class LogRequest
    {
        [Required]
        public int user_id { get; set; }
        [Required]
        public string log { get; set; }
    }
}
