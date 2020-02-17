using System;
using System.ComponentModel.DataAnnotations;

namespace IRunes.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [MinLength(4), MaxLength(10), Required]
        public string Username { get; set; }

        [MinLength(6), Required] //MaxLength(20)
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
