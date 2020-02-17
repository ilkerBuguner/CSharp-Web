using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services.Interfaces
{
    public interface IUsersTripsService
    {
        bool AddUserToTrip(string tripId, string userId);
    }
}
