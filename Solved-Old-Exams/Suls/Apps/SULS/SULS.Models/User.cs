using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [StringLengthSis(5, 20, "Username should be between 5 and 20 characters"), RequiredSis]
        public string Username { get; set; }

        [EmailSis, RequiredSis]
        public string Email { get; set; }

        [RangeSis(6, 20, "Password should be between 6 and 20 characters"), RequiredSis]
        public string Password { get; set; }

        public virtual ICollection<Problem> Problems { get; set; } = new HashSet<Problem>();
    }
}