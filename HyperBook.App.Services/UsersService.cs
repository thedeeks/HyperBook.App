using HyperBook.App.Data;
using System;
using System.Linq;
using HyperBook.App.Interfaces;
using HyperBook.App.Models.ResponseModels;
using System.Security.Cryptography;
using System.Text;
using HyperBook.App.Models.PutModels;

namespace HyperBook.App.Services
{
    public class UsersService: IUsersService
    {

        /// <summary>
        /// HyperBook Context
        /// </summary>
        private HyperBookContext _hyperbookContext { get; set; }

        public UsersService(HyperBookContext hyperbookContext)
        {
            _hyperbookContext = hyperbookContext;
        }

        /// <summary>
        /// Logs the user in to the application
        /// </summary>        
        /// <param name="email">user email</param>
        /// <param name="password">user password</param>
        /// <returns>UserId, FirstName, LastName, EmailAddress</returns>
        public UserResponse Login(string email, string password)
        {
            //Get the hashed password
            string hashedPassword = GetHash(password);

            //Check for the user in DB
            var user = _hyperbookContext.Users.Where(w => w.Email.Trim().ToLower() == email.Trim().ToLower() && w.Password.Trim() == hashedPassword).FirstOrDefault();

            //If not null
            if (user != null)
            {
                return new UserResponse
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    AddressLine1 = user.AddressLine1,
                    AddressLine2 = user.AddressLine2,
                    City = user.City,
                    State = user.State,
                    Zip = user.Zip,
                    Phone = user.Phone
                };
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        /// <summary>
        /// Returns User Info
        /// </summary>        
        /// <returns>UserId, Email, FirstName, LastName, Street, City, State, Zip, Phone</returns>
        public UserResponse GetAccountInfo(Guid userId)
        {
            //Check for the user in DB
            var user = _hyperbookContext.Users.Where(w => w.UserId == userId).FirstOrDefault();

            SHA512 shaM = new SHA512Managed();
            var pass = Convert.ToBase64String(shaM.ComputeHash(Encoding.UTF8.GetBytes(user.Password)));

            //If not null
            if (user != null)
            {
                return new UserResponse 
                { 
                    UserId = user.UserId, 
                    Email = user.Email,  
                    FirstName = user.FirstName, 
                    LastName = user.LastName, 
                    AddressLine1 = user.AddressLine1, 
                    AddressLine2 = user.AddressLine2, 
                    City = user.City, 
                    State = user.State, 
                    Zip = user.Zip, 
                    Phone = user.Phone 
                };
            }
            else
            {
                throw new Exception("User not found");
            }
        }


        /// <summary>
        /// Updates an existing User
        /// </summary>
        /// <param name="user">User Object</param>
        public void UpdateUser(UserUpdateModel user)
        {           
            try
            {
                //Check if user exists
                var existingUser = _hyperbookContext.Users.Where(w => w.UserId == user.UserId).FirstOrDefault();

                if (existingUser == null)
                {
                    throw new Exception("User does not exist");
                }


                #region Check_Required_Fields
                //Check for email
                if (string.IsNullOrEmpty(user.Email) || string.IsNullOrWhiteSpace(user.Email))
                {
                    throw new Exception("Email is required");
                }

                //Check for password
                if (string.IsNullOrEmpty(user.Password) || string.IsNullOrWhiteSpace(user.Password))
                {
                    throw new Exception("Password is required");
                }

                //Check for first name
                if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrWhiteSpace(user.FirstName))
                {
                    throw new Exception("First Name is required");
                }

                //Check for last name
                if (string.IsNullOrEmpty(user.LastName) || string.IsNullOrWhiteSpace(user.LastName))
                {
                    throw new Exception("Last Name is required");
                }

                //Check for Address Line 1
                if (string.IsNullOrEmpty(user.AddressLine1) || string.IsNullOrWhiteSpace(user.AddressLine1))
                {
                    throw new Exception("AddressLine1 is required");
                }

                //Check for City
                if (string.IsNullOrEmpty(user.City) || string.IsNullOrWhiteSpace(user.City))
                {
                    throw new Exception("City is required");
                }

                //Check for State
                if (string.IsNullOrEmpty(user.State) || string.IsNullOrWhiteSpace(user.State))
                {
                    throw new Exception("State is required");
                }

                //Check for Zip
                if (string.IsNullOrEmpty(user.Zip) || string.IsNullOrWhiteSpace(user.Zip))
                {
                    throw new Exception("Zip is required");
                }

                //Check for Phone
                if (string.IsNullOrEmpty(user.Phone) || string.IsNullOrWhiteSpace(user.Phone))
                {
                    throw new Exception("Phone is required");
                }
                #endregion


                #region ValidateFields
                //Validate maxlength for properties
                if (user.Email.Length > 254)
                {
                    throw new Exception("Email maxlength(254) exceeded.");
                }

                if (user.Password.Length > 128)
                {
                    throw new Exception("Password maxlength(128) exceeded.");
                }

                if (user.FirstName.Length > 50)
                {
                    throw new Exception("FirstName maxlength(50) exceeded.");
                }

                if (user.LastName.Length > 50)
                {
                    throw new Exception("LastName maxlength(50) exceeded.");
                }

                if ((!string.IsNullOrEmpty(user.AddressLine1) && !string.IsNullOrWhiteSpace(user.AddressLine1)) && user.AddressLine1.Length > 250)
                {
                    throw new Exception("AddressLine1 maxlength(250) exceeded.");
                }

                if ((!string.IsNullOrEmpty(user.AddressLine2) && !string.IsNullOrWhiteSpace(user.AddressLine2)) && user.AddressLine2.Length > 250)
                {
                    throw new Exception("AddressLine2 maxlength(250) exceeded.");
                }

                if ((!string.IsNullOrEmpty(user.City) && !string.IsNullOrWhiteSpace(user.City)) && user.City.Length > 50)
                {
                    throw new Exception("City maxlength(50) exceeded.");
                }

                if ((!string.IsNullOrEmpty(user.State) && !string.IsNullOrWhiteSpace(user.State)) && user.State.Length > 2)
                {
                    throw new Exception("State maxlength(2) exceeded.");
                }

                if ((!string.IsNullOrEmpty(user.Zip) && !string.IsNullOrWhiteSpace(user.Zip)) && user.Zip.Length > 5)
                {
                    throw new Exception("Zip maxlength(5) exceeded.");
                }

                if ((!string.IsNullOrEmpty(user.Phone) && !string.IsNullOrWhiteSpace(user.Phone)) && user.Phone.Length > 12)
                {
                    throw new Exception("Phone maxlength(12) exceeded.");
                }
                #endregion

                //If Email is changed
                if (existingUser.Email != user.Email)
                {
                    existingUser.Email = user.Email;
                }

                //Get the hashed password
                string hashedPassword = GetHash(user.Password);

                //If Password is changed
                if (existingUser.Password != hashedPassword)
                {
                    existingUser.Password = hashedPassword;
                }

                //If FirstName is changed
                if (existingUser.FirstName != user.FirstName)
                {
                    existingUser.FirstName = user.FirstName;
                }

                //If LastName is changed
                if (existingUser.LastName != user.LastName)
                {
                    existingUser.LastName = user.LastName;
                }

                //If AddressLine1 is changed
                if (existingUser.AddressLine1 != user.AddressLine1)
                {
                    existingUser.AddressLine1 = user.AddressLine1;
                }

                //If AddressLine2 is changed
                if (existingUser.AddressLine2 != user.AddressLine2)
                {
                    existingUser.AddressLine2 = user.AddressLine2;
                }

                //If City is changed
                if (existingUser.City != user.City)
                {
                    existingUser.City = user.City;
                }

                //If State is changed
                if (existingUser.State != user.State)
                {
                    existingUser.State = user.State;
                }

                //If Zip is changed
                if (existingUser.Zip != user.Zip)
                {
                    existingUser.Zip = user.Zip;
                }

                //If Phone is changed
                if (existingUser.Phone != user.Phone)
                {
                    existingUser.Phone = user.Phone;
                }

                //Update the existing user object
                _hyperbookContext.Users.Update(existingUser);
                _hyperbookContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Converts the plain text string to a SHA512Managed hash
        /// </summary>
        /// <param name="password">plain text password</param>
        /// <returns>hashed password in string</returns>
        private string GetHash(string password)
        {

            //Convert plain text to a byte array
            byte[] passBytes = Encoding.UTF8.GetBytes(password);

            SHA512 shaM = new SHA512Managed();

            byte[] hashedPassBytes = shaM.ComputeHash(passBytes);

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < hashedPassBytes.Length; i++)
            {
                sBuilder.Append(hashedPassBytes[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            string hashedPassword = sBuilder.ToString();

            return hashedPassword;
        }

    }
}
