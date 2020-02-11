using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SULS.Services
{
    public class ProblemService : IProblemService
    {
        private readonly SULSContext db;
        private readonly IUserService userService;

        public ProblemService(SULSContext db, IUserService userService)
        {
            this.db = db;
            this.userService = userService;
        }

        public void CreateProblem(string name, int points, string userId)
        {
            var problem = new Problem()
            {
                Name = name,
                Points = points,
                UserId = userId
            };

            db.Problems.Add(problem);
            db.SaveChanges();
        }

        public IQueryable<Problem> GetAllProblems()
        {
            return db.Problems;
        }

        public Problem GetById(string id)
        {
            Problem problem = this.db.Problems.Include(p => p.Submissions).Include(p => p.User).SingleOrDefault(p => p.Id == id);
            return problem;
        }
    }
}
