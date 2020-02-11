using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SULS.Models
{
    public class Submission
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [StringLengthSis(30, 800, "Code should be between 30 and 800 characters"), RequiredSis]
        public string Code { get; set; }

        [RangeSis(0, 300, "AchievedResult should be between 0 and 300 characters"), RequiredSis]
        public int AchievedResult { get; set; }

        [RequiredSis]
        public DateTime CreatedOn { get; set; }

        public string ProblemId { get; set; }

        public virtual Problem Problem { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
