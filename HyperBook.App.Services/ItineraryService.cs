using System;
using System.Collections.Generic;
using System.Linq;
using HyperBook.App.Data;
using HyperBook.App.Interfaces;
using HyperBook.App.Models.ResponseModels;

namespace HyperBook.App.Services
{
    public class ItineraryService : IItineraryService
    {

        #region services
        /// <summary>
        /// HyperBook Context
        /// </summary>
        private HyperBookContext _hyperBookContext { get; set; }
        #endregion


        #region constructor
        public ItineraryService(HyperBookContext hyperBookContext)
        {
            _hyperBookContext = hyperBookContext;
        }
        #endregion

        public IEnumerable<TripResponse> GetTrips(Guid userId)
        {
            try
            {
                //Check if the user exists
                var user = _hyperBookContext.Users.Where(w => w.UserId == userId).FirstOrDefault();

                if(user == null)
                {
                    throw new Exception("User does not exist");
                }

                //Get User's trip
                var trips = _hyperBookContext.Trips.Where(w => w.UserId == userId);

                IEnumerable<TripResponse> response = from trip in trips
                                              select new TripResponse
                                              {
                                                  UserId = trip.UserId,
                                                  PodSchedule = trip.PodSchedule,
                                                  StatusId = trip.StatusId,
                                                  DateCreated = trip.DateCreated,
                                                  DateUpdated = trip.DateUpdated
                                              };

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public IEnumerable<StatusResponse> GetStatus()
        {
            try
            {
                return _hyperBookContext.RefStatuses.Select(s => new StatusResponse { Id = s.Id, Description = s.Description}).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
