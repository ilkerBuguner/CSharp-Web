using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.App.ViewModels.Submissions;
using SULS.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public SubmissionsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        
        [HttpGet]
        [Authorize]
        public IActionResult Create(string id)
        {
            var problem = problemService.GetById(id);
            var viewModel = new ProblemSubmissionViewModel()
            {
                Name = problem.Name,
                ProblemId = problem.Id
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(SubmissionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect($"/Submissions/Create?id={model.ProblemId}");
            }

            this.submissionService.Create(model.Code, model.ProblemId, model.UserId);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            submissionService.Delete(id);

            return this.Redirect("/");
        }
    }
}
