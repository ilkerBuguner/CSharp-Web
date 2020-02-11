using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PANDA.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Packages = new HashSet<Package>();
            Receipts = new HashSet<Receipt>();
        }

        [Key]
        public string Id { get; set; }

        [MinLength(5), MaxLength(20), Required]
        public string Username { get; set; }

        [MinLength(5), MaxLength(20), Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Package> Packages { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
