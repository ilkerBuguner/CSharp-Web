namespace SharedTrip.App.Controllers
{
    using SharedTrip.Services.Interfaces;
    using SharedTrip.ViewModels.Trips;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly ITripsService tripsService;

        public HomeController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse Index()
        {
            if (IsUserLoggedIn())
            {
                var viewModel = new TripListingViewModel()
                {
                    Trips = this.tripsService.GetAll()
                };

                return this.View(viewModel, "../Trips/All");
            };

            return this.View();
        }


        [HttpGet("/")]
        public HttpResponse SlashIndex()
        {
            return this.Index();
        }
    }
}