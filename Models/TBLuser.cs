using Disaster_Guide.Context;
using System.ComponentModel.DataAnnotations;

namespace Disaster_Guide.Models
{
    public class TBLuser 
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }

        [StringLength(10, ErrorMessage = "Password cannot be longer than 10 characters.")]
        public string password { get; set; }
    }
}
