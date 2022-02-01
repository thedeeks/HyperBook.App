using System;
using System.Collections.Generic;
using HyperBook.App.Interfaces;
using HyperBook.App.Models.ResponseModels;

namespace HyperBook.App.Services
{
    public class CitiesService : ICitiesService
    {

        /// <summary>
        /// Builds and Returns a List of cities with respective information
        /// </summary>
        /// <returns>List of CityWithInfoResponse</returns>
        public IEnumerable<CityWithInfoResponse> GetCitiesWithInfo()
        {
            //Instatiate a list
            List<CityWithInfoResponse> cityInforList = new List<CityWithInfoResponse>();

            //Add to the list
            cityInforList.Add(new CityWithInfoResponse 
            {
                City = "New York",
                Latitude = "40.6943",
                Longitude = "-73.9249",
                StateAbbreviation = "NY",
                StateName = "New York",
                Timezone = "America/New_York"
            });

            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Los Angeles",
                Latitude = "34.1139",
                Longitude = "-118.4068",
                StateAbbreviation = "CA",
                StateName = "California",
                Timezone = "America/Los_Angeles"
            });

            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Chicago",
                Latitude = "41.8373",
                Longitude = "-87.6862",
                StateAbbreviation = "IL",
                StateName = "Illinois",
                Timezone = "America/Chicago"
            });

            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Miami",
                Latitude = "25.7839",
                Longitude = "-80.2102",
                StateAbbreviation = "FL",
                StateName = "Florida",
                Timezone = "America/New_York"
            });

            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Dallas",
                Latitude = "32.7936",
                Longitude = "-96.7662",
                StateAbbreviation = "TX",
                StateName = "Texas",
                Timezone = "America/Chicago"
            });

            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Philadelphia",
                Latitude = "40.0077",
                Longitude = "-75.1339",
                StateAbbreviation = "PA",
                StateName = "Pennsylvania",
                Timezone = "America/New_York"
            });

            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Houston",
                Latitude = "29.7863",
                Longitude = "-95.3889",
                StateAbbreviation = "TX",
                StateName = "Texas",
                Timezone = "America/Chicago"
            });

            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Atlanta",
                Latitude = "33.7627",
                Longitude = "-84.4224",
                StateAbbreviation = "GA",
                StateName = "Georgia",
                Timezone = "America/New_York"
            });

            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Washington",
                Latitude = "38.9047",
                Longitude = "-77.0163",
                StateAbbreviation = "DC",
                StateName = "District of Columbia",
                Timezone = "America/New_York"
            });

            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Boston",
                Latitude = "42.3188",
                Longitude = "-71.0846",
                StateAbbreviation = "MA",
                StateName = "Massachusetts",
                Timezone = "America/New_York"
            });

            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Phoenix",
                Latitude = "33.5722",
                Longitude = "-112.0891",
                StateAbbreviation = "AZ",
                StateName = "Arizona",
                Timezone = "America/Phoenix"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Seattle",
                Latitude = "47.6211",
                Longitude = "-122.3244",
                StateAbbreviation = "WA",
                StateName = "Washington",
                Timezone = "America/Los_Angeles"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "San Francisco",
                Latitude = "37.7562",
                Longitude = "-122.443",
                StateAbbreviation = "CA",
                StateName = "California",
                Timezone = "America/Los_Angeles"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Detroit",
                Latitude = "42.3834",
                Longitude = "-83.1024",
                StateAbbreviation = "MI",
                StateName = "Michigan",
                Timezone = "America/Detroit"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "San Diego",
                Latitude = "32.8312",
                Longitude = "-117.1225",
                StateAbbreviation = "CA",
                StateName = "California",
                Timezone = "America/Los_Angeles"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Minneapolis",
                Latitude = "44.9635",
                Longitude = "-93.2678",
                StateAbbreviation = "MN",
                StateName = "Minnesota",
                Timezone = "America/Chicago"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Tampa",
                Latitude = "27.9942",
                Longitude = "-82.4451",
                StateAbbreviation = "FL",
                StateName = "Florida",
                Timezone = "America/New_York"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Denver",
                Latitude = "39.7621",
                Longitude = "-104.8759",
                StateAbbreviation = "CO",
                StateName = "Colorado",
                Timezone = "America/Denver"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Las Vegas",
                Latitude = "36.2333",
                Longitude = "-115.2654",
                StateAbbreviation = "NV",
                StateName = "Nevada",
                Timezone = "America/Los_Angeles"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Portland",
                Latitude = "45.5372",
                Longitude = "-122.65",
                StateAbbreviation = "OR",
                StateName = "Oregon",
                Timezone = "America/Los_Angeles"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "San Antonio",
                Latitude = "29.4658",
                Longitude = "-98.5253",
                StateAbbreviation = "TX",
                StateName = "Texas",
                Timezone = "America/Chicago"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "St. Louis",
                Latitude = "38.6358",
                Longitude = "-90.2451",
                StateAbbreviation = "MO",
                StateName = "Missouri",
                Timezone = "America/Chicago"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Sacramento",
                Latitude = "38.5667",
                Longitude = "-121.4683",
                StateAbbreviation = "CA",
                StateName = "California",
                Timezone = "America/Los_Angeles"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Orlando",
                Latitude = "28.4772",
                Longitude = "-81.3369",
                StateAbbreviation = "FL",
                StateName = "Florida",
                Timezone = "America/New_York"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Austin",
                Latitude = "30.3004",
                Longitude = "-97.7522",
                StateAbbreviation = "TX",
                StateName = "Texas",
                Timezone = "America/Chicago"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Cincinnati",
                Latitude = "39.1413",
                Longitude = "-84.5061",
                StateAbbreviation = "OH",
                StateName = "Ohio",
                Timezone = "America/New_York"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Nashville",
                Latitude = "36.1715",
                Longitude = "-86.7843",
                StateAbbreviation = "TN",
                StateName = "Tennessee",
                Timezone = "America/Chicago"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "Raleigh",
                Latitude = "35.8325",
                Longitude = "-78.6435",
                StateAbbreviation = "NC",
                StateName = "North Carolina",
                Timezone = "America/New_York"
            });
            cityInforList.Add(new CityWithInfoResponse
            {
                City = "New Orleans",
                Latitude = "30.0687",
                Longitude = "-89.9288",
                StateAbbreviation = "LA",
                StateName = "Louisiana",
                Timezone = "America/Chicago"
            });

            return cityInforList;
        }
    }
}
