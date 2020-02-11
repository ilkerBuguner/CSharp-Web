using SULS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Problems
{
    public class SubmissionDetailsViewModel
    {
        public string SubmissionId { get; set; }

        public string Username { get; set; }

        public int AchievedResult { get; set; }

        public int MaxPoints { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ProblemId { get; set; }

        public User User { get; set; }
    }
}
