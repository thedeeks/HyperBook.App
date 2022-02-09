using System;
using System.Collections.Generic;
using HyperBook.App.Interfaces;
using HyperBook.App.Data;
using HyperBook.App.Models.ResponseModels;
using System.Linq;

namespace HyperBook.App.Services
{
    public class CitiesService : ICitiesService
    {
        /// <summary>
        /// HyperBook Context
        /// </summary>
        private HyperBookContext _hyperbookContext { get; set; }

        public CitiesService(HyperBookContext hyperbookContext)
        {
            _hyperbookContext = hyperbookContext;
        }

        /// <summary>
        /// Returns a list of cities with information about them
        /// </summary>
        /// <returns>Returns a list of CityWithInfoResponse object</returns>
        public IEnumerable<CityWithInfoResponse> GetCitiesWithInfo()
        {
            //Get all cities
            var cities = _hyperbookContext.Cities.ToList();


            //Map the properties to the response object
            IEnumerable<CityWithInfoResponse> listOfCities = from city in cities                        
                        select new CityWithInfoResponse
                        {
                            Id = city.Id,
                            City = city.Name,
                            Latitude = city.Latitude,
                            Longitude = city.Longitude,
                            State = city.State
                        };

            //return list of cities
            return listOfCities;
        }


        /// <summary>
        /// Returns a collection of pod schedules
        /// </summary>
        /// <param name="cityId">City From</param>
        /// <param name="cityDestinationId">City To</param>
        /// <returns>A collection of PodScheduleResponse objects</returns>
        /// [ApiExplorerSettings(GroupName = "HyperBook")]
        public IEnumerable<PodScheduleResponse> GetPodSchedule(int cityId, int cityDestinationId)
        {
            var podSchedules = _hyperbookContext.PodSchedules.Where(w => w.CityFrom == cityId && w.CityTo == cityDestinationId);
            IEnumerable<PodScheduleResponse> response = new List<PodScheduleResponse>();

            if (podSchedules != null)
            {
                response = from schedule in podSchedules
                           select new PodScheduleResponse
                           {
                               Id = schedule.Id,
                               CityFrom = schedule.CityFrom,
                               CityTo = schedule.CityTo,
                               DepartureTimeGmt = schedule.DepartureTimeGmt,
                               ArrivalTimeGmt = schedule.ArrivalTimeGmt,
                               Price = schedule.Price
                           };
            }
            
            return response;
        }
    }
}
