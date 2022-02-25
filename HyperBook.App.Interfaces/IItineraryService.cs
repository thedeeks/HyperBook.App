using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperBook.App.Models.ResponseModels;

namespace HyperBook.App.Interfaces
{
    public interface IItineraryService
    {
        IEnumerable<TripResponse> GetTrips(Guid userId);

        IEnumerable<StatusResponse> GetStatus();
    }
}
