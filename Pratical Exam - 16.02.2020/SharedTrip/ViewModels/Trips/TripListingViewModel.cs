using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class TripListingViewModel
    {
        public IEnumerable<TripInfoViewModel> Trips { get; set; }
    }
}
