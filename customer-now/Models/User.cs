using System.ComponentModel.DataAnnotations;

namespace customer_now.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // "Customer" or "Support"

    }

}

