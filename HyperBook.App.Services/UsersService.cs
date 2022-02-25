using HyperBook.App.Data;
using System;
using System.Linq;
using HyperBook.App.Interfaces;
using HyperBook.App.Models.ResponseModels;

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
            //Check for the user in DB
            var user = _hyperbookContext.Users.Where(w => w.Email.Trim().ToLower() == email.Trim().ToLower() && w.Password.Trim().ToLower() == password.Trim().ToLower()).FirstOrDefault();

            //If not null
            if (user != null)
            {
                return new UserResponse { UserId = user.UserId, FirstName = user.FirstName, LastName = user.LastName, Email = email};
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

            //If not null
            if (user != null)
            {
                return new UserResponse { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, City = user.City, Phone = user.Phone, State = user.State, Street = user.AddressLine1, Zip = user.Zip, UserId = user.UserId };
            }
            else
            {
                throw new Exception("User not found");
            }
        }
    }
}
