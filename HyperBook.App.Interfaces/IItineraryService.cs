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

        IEnumerable<DestinationResponse> GetDestinations(int cityId);

        /// <summary>
        /// Updates the Trip Status
        /// </summary>
        /// <param name="tripId"></param>
        /// <param name="refStatusId"></param>
        void UpdateTripStatus(int tripId, int refStatusId);

        /// <summary>
        /// Deletes a trip record
        /// </summary>
        /// <param name="tripId"></param>
        void DeleteTrip(int tripId);

    }
}
