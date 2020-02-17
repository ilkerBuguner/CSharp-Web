using SharedTrip.Models;
using SharedTrip.Services.Interfaces;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string startPoint, string endPoint,
            string departureTime, string imagePath,
            int seats, string description)
        {
            var trip = new Trip()
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = DateTime.ParseExact(departureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = imagePath,
                Seats = seats,
                Description = description
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public IQueryable<TripInfoViewModel> GetAll()
        {
            return this.db.Trips.Select(t => new TripInfoViewModel
            {
                Id = t.Id,
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
                DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                Seats = t.Seats
            });
        }

        public TripDetailsViewModel GetById(string tripId)
        {
            var trip = this.db.Trips.FirstOrDefault(t => t.Id == tripId);

            var tripDetailsViewModel = new TripDetailsViewModel()
            {
                Id = trip.Id,
                Description = trip.Description,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                ImagePath = trip.ImagePath,
                DepartureTime = trip.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Seats = trip.Seats
            };
            ;
            return tripDetailsViewModel;
        }
    }
}
