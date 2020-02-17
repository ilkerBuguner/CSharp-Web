using SharedTrip.Models;
using SharedTrip.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class UsersTripsService : IUsersTripsService
    {
        private readonly ApplicationDbContext db;

        public UsersTripsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public bool AddUserToTrip(string tripId, string userId)
        {
            var trip = this.db.Trips.FirstOrDefault(t => t.Id == tripId);
            var user = this.db.Users.FirstOrDefault(u => u.Id == userId);

            if (this.db.UsersTrips.Any(ut => ut.TripId == tripId && ut.UserId == userId))
            {
                return false;
            }

            var userTrip = new UserTrip()
            {
                UserId = userId,
                TripId = tripId
            };

            this.db.UsersTrips.Add(userTrip);

            trip.Seats -= 1;

            this.db.SaveChanges();
            return true;
        }
    }
}
