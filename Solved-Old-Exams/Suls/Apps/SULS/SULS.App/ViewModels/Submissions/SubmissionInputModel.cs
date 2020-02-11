using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Submissions
{
    public class SubmissionInputModel
    {
        [StringLengthSis(30, 800, "Code should be between 30 and 800 characters"), RequiredSis]
        public string Code { get; set; }

        [RequiredSis]
        public string ProblemId { get; set; }

        [RequiredSis]
        public string UserId { get; set; }
    }
}
