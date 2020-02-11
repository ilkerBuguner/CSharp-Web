using PANDA.Models.Enums;
using PANDA.Services.Interfaces;
using PANDA.ViewModels.Packages;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PANDA.Controllers
{
    public class PackagesController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;
        private readonly IPackageService packageService;
        private readonly IReceiptsService receiptsService;

        public PackagesController(ApplicationDbContext db, IUsersService usersService, IPackageService packageService, IReceiptsService receiptsService)
        {
            this.db = db;
            this.usersService = usersService;
            this.packageService = packageService;
            this.receiptsService = receiptsService;
        }
        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var list = usersService.GetUsernames();
            return this.View(list);
        }

        [HttpPost]
        public HttpResponse Create(PackageCreateInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Description?.Length < 5 || input.Description?.Length > 20 || string.IsNullOrWhiteSpace(input.Description))
            {
                return this.Redirect("/Package/Create");
            }

            this.packageService.CreatePackage(input.Description, input.Weight, input.ShippingAddress, input.RecipientName);

            return this.Redirect("/Packages/Pending");
        }

        public HttpResponse Pending()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var packages = this.packageService.GetAllByStatus(Status.Pending)
                .Select(x => new PackageViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    RecipientName = x.Recipient.Username,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight
                }).ToList();

            var packagesModel = new PackagListingViewModel();
            packagesModel.Packages = packages;
            return this.View(packagesModel);
        }

        public HttpResponse Delivered()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var packages = this.packageService.GetAllByStatus(Status.Delivered)
                .Select(x => new PackageViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    RecipientName = x.Recipient.Username,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight
                }).ToList();

            var packagesModel = new PackagListingViewModel();
            packagesModel.Packages = packages;
            return this.View(packagesModel);
        }

        public HttpResponse Deliver(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.packageService.Deliver(id);

            return this.Redirect("/Packages/Delivered");
        }
    }
}
