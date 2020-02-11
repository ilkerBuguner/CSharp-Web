using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SULS.Services
{
    public interface IProblemService
    {
        void CreateProblem(string name, int points, string userId);

        IQueryable<Problem> GetAllProblems();

        Problem GetById(string id);
    }
}
