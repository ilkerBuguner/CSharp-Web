using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Users;
using SULS.Services;
using System.Security.Cryptography;

namespace SULS.App.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService usersService;

        public UsersController(IUserService usersService)
        {
            this.usersService = usersService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            var user = usersService.GetUserOrNull(input.Username, input.Password);

            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(user.Id, user.Username, user.Email);

            return this.Redirect("/Home/Index");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            usersService.CreateUser(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}