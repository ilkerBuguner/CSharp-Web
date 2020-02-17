using IRunes.App.ViewModels.Home;
using IRunes.Services.Interfaces;
using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunes.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                string username = this.usersService.GetUsernameById(this.User);
                var viewModel = new LoggedInViewModel() { Username = username };
                return this.View(viewModel, "Home");
            }

            return this.View();
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }
    }
}
