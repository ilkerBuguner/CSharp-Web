using Microsoft.EntityFrameworkCore;
using PANDA.Services;
using PANDA.Services.Interfaces;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PANDA
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IPackageService, PackageService>();
            serviceCollection.Add<IReceiptsService, ReceiptsService>();
        }

        public void Configure(IList<Route> routeTable)
        {
            var db = new ApplicationDbContext();
            db.Database.Migrate();
        }
    }
}
