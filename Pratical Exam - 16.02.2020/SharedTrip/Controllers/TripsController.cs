using SharedTrip.Services.Interfaces;
using SharedTrip.ViewModels.Trips;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;
        private readonly IUsersTripsService usersTripsService;

        public TripsController(ITripsService tripsService, IUsersTripsService usersTripsService)
        {
            this.tripsService = tripsService;
            this.usersTripsService = usersTripsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (String.IsNullOrWhiteSpace(input.StartPoint))
            {
                return this.Redirect("/Trips/Add");
            }

            if (String.IsNullOrWhiteSpace(input.EndPoint))
            {
                return this.Redirect("/Trips/Add");
            }

            if (String.IsNullOrWhiteSpace(input.DepartureTime))
            {
                return this.Redirect("/Trips/Add");
            }

            try
            {
                DateTime.ParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return this.Redirect("/Trips/Add");
            }

            if (input.Seats < 2  || input.Seats > 6)
            {
                return this.Redirect("/Trips/Add");
            }

            if (input.Description.Length > 80 || String.IsNullOrWhiteSpace(input.Description))
            {
                return this.Redirect("/Trips/Add");
            }

            this.tripsService.Create(input.StartPoint, input.EndPoint,
                input.DepartureTime, input.ImagePath,
                input.Seats, input.Description);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new TripListingViewModel()
            {
                Trips = this.tripsService.GetAll()
            };

            return this.View(viewModel);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.tripsService.GetById(tripId);

            return this.View(viewModel);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            bool isUserAddedToTrip = this.usersTripsService.AddUserToTrip(tripId, this.User);

            if (isUserAddedToTrip == false)
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            return this.All();
        }
    }
}
