using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.Data;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly SULSContext db;
        private readonly IProblemService problemService;

        public HomeController(SULSContext db, IProblemService problemService)
        {
            this.db = db;
            this.problemService = problemService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var problems = problemService.GetAllProblems().Select(p => new ProblemViewModel
                {
                    Id = p.Id,
                    Count = p.Submissions.Count,
                    Name = p.Name
                }).ToList();

                return this.View(problems, "IndexLoggedIn");
            }
            else
            {
                return this.View();
            }
        }

       
    }
}