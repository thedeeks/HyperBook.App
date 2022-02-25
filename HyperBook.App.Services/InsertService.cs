using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperBook.App.Interfaces;
using HyperBook.App.Models.PostModels;
using HyperBook.App.Data;
using HyperBook.App.Data.Model;

namespace HyperBook.App.Services
{
    public class InsertService: IInsertService
    {
        #region services
        /// <summary>
        /// HyperBook Context
        /// </summary>
        private HyperBookContext _hyperBookContext { get; set; }
        #endregion


        #region constructor
        public InsertService(HyperBookContext hyperBookContext)
        {
            _hyperBookContext = hyperBookContext;
        }
        #endregion


        /// <summary>
        /// Add a User
        /// </summary>
        /// <param name="userModel"></param>
        public string AddUser(UserModel userModel)
        {
            //Check for email
            if (string.IsNullOrEmpty(userModel.Email) || string.IsNullOrWhiteSpace(userModel.Email))
            {
                throw new Exception("Email is required");
            }

            //Check for password
            if (string.IsNullOrEmpty(userModel.Password) || string.IsNullOrWhiteSpace(userModel.Password))
            {
                throw new Exception("Password is required");
            }

            //Check for first name
            if (string.IsNullOrEmpty(userModel.FirstName) || string.IsNullOrWhiteSpace(userModel.FirstName))
            {
                throw new Exception("First Name is required");
            }

            //Check for last name
            if (string.IsNullOrEmpty(userModel.LastName) || string.IsNullOrWhiteSpace(userModel.LastName))
            {
                throw new Exception("Last Name is required");
            }

            
            //Validate maxlength for properties
            if (userModel.Email.Length > 254)
            {
                throw new Exception("Email maxlength(254) exceeded.");
            }

            if (userModel.Password.Length > 128)
            {
                throw new Exception("Password maxlength(128) exceeded.");
            }

            if (userModel.FirstName.Length > 50)
            {
                throw new Exception("FirstName maxlength(50) exceeded.");
            }

            if (userModel.LastName.Length > 50)
            {
                throw new Exception("LastName maxlength(50) exceeded.");
            }

            if( (!string.IsNullOrEmpty(userModel.AddressLine1) && !string.IsNullOrWhiteSpace(userModel.AddressLine1)) && userModel.AddressLine1.Length > 250)
            {
                throw new Exception("AddressLine1 maxlength(250) exceeded.");
            }

            if ((!string.IsNullOrEmpty(userModel.AddressLine2) && !string.IsNullOrWhiteSpace(userModel.AddressLine2)) && userModel.AddressLine2.Length > 250)
            {
                throw new Exception("AddressLine2 maxlength(250) exceeded.");
            }

            if ((!string.IsNullOrEmpty(userModel.City) && !string.IsNullOrWhiteSpace(userModel.City)) && userModel.City.Length > 50)
            {
                throw new Exception("City maxlength(50) exceeded.");
            }

            if ((!string.IsNullOrEmpty(userModel.State) && !string.IsNullOrWhiteSpace(userModel.State)) && userModel.State.Length > 2)
            {
                throw new Exception("State maxlength(2) exceeded.");
            }

            if ((!string.IsNullOrEmpty(userModel.Zip) && !string.IsNullOrWhiteSpace(userModel.Zip)) && userModel.Zip.Length > 5)
            {
                throw new Exception("Zip maxlength(5) exceeded.");
            }

            if ((!string.IsNullOrEmpty(userModel.Phone) && !string.IsNullOrWhiteSpace(userModel.Phone)) && userModel.Phone.Length > 12)
            {
                throw new Exception("Phone maxlength(12) exceeded.");
            }

            //Check if the user already exists
            var existingUser = _hyperBookContext.Users.Where(w => w.Email.ToLower() == userModel.Email.ToLower() && w.Password.ToLower() == userModel.Password.ToLower()).FirstOrDefault();

            //Throw an error if user already exists
            if (existingUser != null)
            {
                throw new Exception("User Exists");
            }

            //Create new user object
            User newUser = new User();
            try
            {
                newUser.UserId = Guid.NewGuid();
                newUser.FirstName = userModel.FirstName;
                newUser.LastName = userModel.LastName;
                newUser.Email = userModel.Email;
                newUser.Password = userModel.Password;
                newUser.AddressLine1 = userModel.AddressLine1;
                newUser.AddressLine2 = userModel.AddressLine2;
                newUser.City = userModel.City;
                newUser.State = userModel.State;
                newUser.Zip = userModel.Zip;
                newUser.Phone = userModel.Phone;

                //Add User
                _hyperBookContext.Add(newUser);
                _hyperBookContext.SaveChanges();


                Guid newUserId = _hyperBookContext.Users.Where(w => w.Email.ToLower() == userModel.Email.ToLower() &&
                    w.Password.ToLower() == userModel.Password.ToLower() && w.FirstName.ToLower() == userModel.FirstName.ToLower() 
                    && w.LastName.ToLower() == userModel.LastName.ToLower()).FirstOrDefault().UserId;

                return newUserId.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add user. {ex.Message}");
            }
        }


        /// <summary>
        /// Add a City
        /// </summary>
        /// <param name="cityModel"></param>
        /// <returns></returns>
        public string AddCity(CityModel cityModel)
        {
            try
            {
                //Check for required values
                if(string.IsNullOrEmpty(cityModel.Name) || string.IsNullOrWhiteSpace(cityModel.Name))
                {
                    throw new Exception("Name is required");
                }

                if (string.IsNullOrEmpty(cityModel.State) || string.IsNullOrWhiteSpace(cityModel.State))
                {
                    throw new Exception("State is required");
                }

                if (string.IsNullOrEmpty(cityModel.Timezone) || string.IsNullOrWhiteSpace(cityModel.Timezone))
                {
                    throw new Exception("Timezone is required");
                }

                //Check for max length
                if(cityModel.Name.Length > 75)
                {
                    throw new Exception("Name exceeds maxlength of 75");
                }

                if (cityModel.State.Length > 2)
                {
                    throw new Exception("State exceeds maxlength of 2");
                }

                if (cityModel.Timezone.Length > 75)
                {
                    throw new Exception("Timezone exceeds maxlength of 75");
                }


                //Check if city exists in the DB
                var existingCity = _hyperBookContext.Cities.Where(w => w.Name.ToLower() == cityModel.Name.ToLower()).FirstOrDefault();

                if(existingCity != null)
                {
                    throw new Exception("City exists in the DB.");
                }

                //Create a new City Object
                City newCity = new City()
                {
                    Name = cityModel.Name,
                    Longitude = cityModel.Longitude,
                    Latitude = cityModel.Latitude,
                    State = cityModel.State,
                    Timezone = cityModel.Timezone
                };

                _hyperBookContext.Add(newCity);
                _hyperBookContext.SaveChanges();

                int newCityId = _hyperBookContext.Cities.Where(w => w.Name.ToLower() == cityModel.Name.ToLower() && w.Longitude == cityModel.Longitude
                    && w.Latitude == cityModel.Latitude && w.State == cityModel.State 
                    && w.Timezone.ToLower() == cityModel.Timezone.ToLower()).FirstOrDefault().Id;

                return newCityId.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add city. {ex.Message}");
            }
        }


        /// <summary>
        /// Add a Pod Schedule
        /// </summary>
        /// <param name="podSchedule"></param>
        /// <returns></returns>
        public string AddPodSchedule(PodScheduleModel podSchedule)
        {
            try
            {
                //Check for valid values
                if (podSchedule.CityFrom <= 0)
                {
                    throw new Exception("Invalid CityFrom ID");
                }

                if (podSchedule.CityTo <= 0)
                {
                    throw new Exception("Invalid CityTo ID");
                }

                if(string.IsNullOrEmpty(podSchedule.DepartureWindow) || string.IsNullOrWhiteSpace(podSchedule.DepartureWindow))
                {
                    throw new Exception("Invalid DepartureWindow");
                }


                //Check if the cities exist
                var departureCity = _hyperBookContext.Cities.Where(w => w.Id == podSchedule.CityFrom).FirstOrDefault();
                
                if(departureCity == null)
                {
                    throw new Exception("CityFrom does not exist in the DB.");
                }

                var arrivalCity = _hyperBookContext.Cities.Where(w => w.Id == podSchedule.CityTo).FirstOrDefault();

                if (arrivalCity == null)
                {
                    throw new Exception("CityTo does not exist in the DB.");
                }

                //Create a new Pod Schedule
                PodSchedule newPodSchedule = new PodSchedule()
                {
                    CityFrom = podSchedule.CityFrom,
                    CityTo = podSchedule.CityTo,
                    DepartureWindow = podSchedule.DepartureWindow,
                    Price = podSchedule.Price
                };

                _hyperBookContext.Add(newPodSchedule);
                _hyperBookContext.SaveChanges();

                int newPodId = _hyperBookContext.PodSchedules.Where(w => w.CityFrom == podSchedule.CityFrom && w.CityTo == podSchedule.CityTo &&
                    w.DepartureWindow == podSchedule.DepartureWindow && w.Price == podSchedule.Price).FirstOrDefault().Id;
                
                
                return newPodId.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add a new Pod Schedule. {ex.Message}");
            }

        }


        /// <summary>
        /// Add Ref Status
        /// </summary>
        /// <param name="refStatus"></param>
        /// <returns></returns>
        public string AddRefStatus(RefStatusModel refStatus)
        {   
            try
            {

                //Check if empty
                if (string.IsNullOrEmpty(refStatus.Description) || string.IsNullOrWhiteSpace(refStatus.Description))
                {
                    throw new Exception("Description cannot be empty.");
                }

                //Check max length constaints
                if(refStatus.Description.Length > 250)
                {
                    throw new Exception("Description cannot exceed max length of 250.");
                }

                //Create a new Ref Status objet
                RefStatus newRefStatus = new RefStatus()
                {
                    Description = refStatus.Description
                };

                _hyperBookContext.Add(newRefStatus);
                _hyperBookContext.SaveChanges();

                int refStatusId = _hyperBookContext.RefStatuses.Where(w => w.Description.ToLower() == refStatus.Description.ToLower()).FirstOrDefault().Id; 

                return refStatusId.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to enter a new ref status. {ex.Message}");
            }
        }


        /// <summary>
        /// Add a new trip
        /// </summary>
        /// <param name="tripModel"></param>
        /// <returns></returns>
        public string AddTrip(TripModel tripModel)
        {
            try
            {
                //check for valid values
                if (tripModel.PodSchedule <= 0)
                {
                    throw new Exception("Invalid Pod Schedule Id.");
                }

                //check if user exists
                var user = _hyperBookContext.Users.Where(w => w.UserId == tripModel.UserId).FirstOrDefault();

                if (user == null)
                {
                    throw new Exception("User does not exist in the db.");
                }

                //check for valid values
                if (tripModel.StatusId <= 0)
                {
                    throw new Exception("Invalid Ref Status Id.");
                }

                //Check if pod schedule exists in the db
                var podSchedule = _hyperBookContext.PodSchedules.Where(w => w.Id == tripModel.PodSchedule).FirstOrDefault();

                if (podSchedule == null)
                {
                    throw new Exception("Pod Schedule does not exist in the db.");
                }

                //Check if ref status exist
                var refStatus = _hyperBookContext.RefStatuses.Where(w => w.Id == tripModel.StatusId).FirstOrDefault();

                if (refStatus == null)
                {
                    throw new Exception("Ref Status does not exist.");
                }

                //Create a new trip
                Trip newTrip = new Trip()
                {
                    UserId = tripModel.UserId,
                    PodSchedule = tripModel.PodSchedule,
                    StatusId = tripModel.StatusId,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };

                _hyperBookContext.Add(newTrip);
                _hyperBookContext.SaveChanges();

                int newTripId = _hyperBookContext.Trips.Where(w => w.UserId == tripModel.UserId && w.PodSchedule == tripModel.PodSchedule && w.StatusId == tripModel.StatusId
                    && w.DateCreated == newTrip.DateCreated && w.DateUpdated == newTrip.DateUpdated).FirstOrDefault().Id;
                
                return newTripId.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add a new trip. {ex.Message}");
            }
        }
    }
}
