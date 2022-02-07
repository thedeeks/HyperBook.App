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
        /// Builds and Returns a List of cities with respective information
        /// </summary>
        /// <returns>List of CityWithInfoResponse</returns>
        public IEnumerable<CityWithInfoResponse> GetCitiesWithInfo()
        {
            var cities = _hyperbookContext.Cities.ToList();
            var states = _hyperbookContext.States.ToList();


            //Create a query
            IEnumerable<CityWithInfoResponse> listOfCities = from city in cities
                        join state in states on city.StateId equals state.Id
                        select new CityWithInfoResponse
                        {
                            City = city.Name,
                            Latitude = city.Latitude,
                            Longitude = city.Longitude,
                            StateAbbreviation = state.Abbreviation,
                            StateName = state.Name,
                            Timezone = city.Timezone
                        };

            //Add to the list

            return listOfCities;
        }
    }
}
