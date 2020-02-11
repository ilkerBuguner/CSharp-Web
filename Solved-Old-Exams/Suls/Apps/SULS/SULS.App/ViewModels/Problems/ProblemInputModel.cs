using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemInputModel
    {
        [StringLengthSis(5, 20, "Name should be between 5 and 20 characters"), RequiredSis]
        public string Name { get; set; }

        [RangeSis(50, 300, "Points should be between 50 and 300 characters"), RequiredSis]
        public int Points { get; set; }

        [RequiredSis]
        public string UserId { get; set; }
    }
}
