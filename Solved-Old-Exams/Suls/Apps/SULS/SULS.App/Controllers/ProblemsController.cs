using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;

        public ProblemsController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(ProblemInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            problemService.CreateProblem(input.Name, input.Points, input.UserId);

            return this.Redirect("/Home/Index");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var problem = problemService.GetById(id);

            var model = new ProblemDetailsViewModel
            {
                Name = problem.Name,
                Submissions = problem.Submissions.Select(s => new SubmissionDetailsViewModel
                {
                    SubmissionId = s.Id,
                    Username = s.User.Username,
                    AchievedResult = s.AchievedResult,
                    MaxPoints = s.Problem.Points,
                    CreatedOn = s.CreatedOn,
                    ProblemId = s.ProblemId
                }).ToList()
            };

            return this.View(model);
        }
    }
}
