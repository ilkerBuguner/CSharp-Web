using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedTrip.Services.Interfaces
{
    public interface ITripsService
    {
        void Create(string startPoint, string endPoint, string departureTime, string imagePath, int seats, string description);

        IQueryable<TripInfoViewModel> GetAll();

        TripDetailsViewModel GetById(string id);
    }
}
