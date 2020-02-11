using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SULS.Models
{
    public class Problem
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [StringLengthSis(5,20, "Name should be between 5 and 20 characters") , RequiredSis]
        public string Name { get; set; }

        [RangeSis(50, 300, "Points should be between 50 and 300 characters"), RequiredSis]
        public int Points { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Submission> Submissions { get; set; } = new HashSet<Submission>();
    }
}
