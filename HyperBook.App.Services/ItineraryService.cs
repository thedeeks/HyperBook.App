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
                var trips = _hyperBookContext.Trips.Where(w => w.UserId == userId).ToList();
                var podIds = trips.Select(s => s.PodSchedule).ToList();
                var podSchedules = _hyperBookContext.PodSchedules.Where(w => podIds.Contains(w.Id)).ToList();
                var refStatus = _hyperBookContext.RefStatuses.ToList();
                var cities = _hyperBookContext.Cities.ToList();

                var flattenedTrips = from trip in trips
                                     join pod in podSchedules on trip.PodSchedule equals pod.Id
                                     join departureCity in cities on pod.CityFrom equals departureCity.Id
                                     join arrivalCity in cities on pod.CityTo equals arrivalCity.Id
                                     join status in refStatus on trip.StatusId equals status.Id
                                     select new TripResponse
                                     {
                                         UserId = trip.UserId,
                                         PodSchedule = new PodResponse { CityFrom = departureCity.Name, CityTo = arrivalCity.Name, DepartureWindow = pod.DepartureWindow, Price = pod.Price},
                                         RefStatus = status.Description,
                                         DateCreated = trip.DateCreated,
                                         DateUpdated = trip.DateUpdated,
                                         TripId = trip.Id
                                     };

                var response = flattenedTrips.ToList();
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


        public IEnumerable<DestinationResponse> GetDestinations(int cityId)
        {
            try
            {
                var departureCity = _hyperBookContext.Cities.Where(w => w.Id == cityId).FirstOrDefault();

                if(departureCity == null)
                {
                    throw new Exception("Invalid cityId.");
                }

                //Get all the pod schedules for the departing city id
                var podSchedules = _hyperBookContext.PodSchedules.Where(w => w.CityFrom == cityId).ToList();

                //Get all distinct the arrival cityIds
                List<int> arrivalCityIds = podSchedules.Select(s => s.CityTo).Distinct().ToList();

                //Get the arrival cityInfo
                var arrivalCities = _hyperBookContext.Cities.Where(w => arrivalCityIds.Contains(w.Id)).ToList();

                //Flatten out the data and create the response object
                var destinations = from pod in podSchedules
                                   join arrivalCity in arrivalCities on pod.CityTo equals arrivalCity.Id
                                   select new DestinationResponse
                                   {
                                       PodId = pod.Id,
                                       CityFrom = pod.CityFrom,
                                       CityFromName = departureCity.Name,
                                       CityTo = new CityWithInfoResponse { Id = arrivalCity.Id, Latitude = arrivalCity.Latitude, Longitude = arrivalCity.Longitude, Name = arrivalCity.Name, State = arrivalCity.State, Timezone = arrivalCity.Timezone },
                                       DepartureWindow = pod.DepartureWindow,
                                       Price = pod.Price
                                   };

                return destinations.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Updates the Trip Status
        /// </summary>
        /// <param name="tripId"></param>
        /// <param name="refStatusId"></param>
        public void UpdateTripStatus(int tripId, int refStatusId)
        {
            try
            {
                var trip = _hyperBookContext.Trips.Where(w => w.Id == tripId).FirstOrDefault();

                if(trip.StatusId != refStatusId)
                {
                    trip.StatusId = refStatusId;
                    _hyperBookContext.Trips.Update(trip);
                    _hyperBookContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Deletes a trip record
        /// </summary>
        /// <param name="tripId"></param>
        public void DeleteTrip(int tripId)
        {
            try
            {
                var trip = _hyperBookContext.Trips.Where(w => w.Id == tripId).FirstOrDefault();

                _hyperBookContext.Trips.Remove(trip);
                _hyperBookContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
