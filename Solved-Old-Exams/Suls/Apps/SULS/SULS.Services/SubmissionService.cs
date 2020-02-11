using SULS.Data;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly SULSContext db;
        private readonly ProblemService problemService;

        public SubmissionService(SULSContext db, ProblemService problemService)
        {
            this.db = db;
            this.problemService = problemService;
        }

        public void Create(string code, string problemId, string userId)
        {
            var problem = problemService.GetById(problemId);

            var submission = new Submission
            {
                Code = code,
                AchievedResult = GetRandomNumber(0, problem.Points),
                CreatedOn = DateTime.UtcNow,
                UserId = userId,
                ProblemId = problemId
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = db.Submissions.FirstOrDefault(s => s.Id == id);

            db.Submissions.Remove(submission);
            db.SaveChanges();
        }

        private int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
