using Mecca.API.Model;
using System.Text.Json.Serialization;

namespace Mecca.API.Data.ValueObjects
{
    public class UserLogVO
    {
        public int id { get; set; }
        public int user_id { get; set; }        
        public string log { get; set; }        
        public DateTime included { get; set; }        
        public User user { get; set; }     
    }
}
