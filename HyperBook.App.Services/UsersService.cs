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

        public UserResponse Login(string email, string password)
        {            
            var user = _hyperbookContext.Users.Where(w => w.Email.Trim().ToLower() == email.Trim().ToLower() && w.Password.Trim().ToLower() == password.Trim().ToLower()).FirstOrDefault();

            if (user != null)
            {
                return new UserResponse { UserId = user.UserId, FirstName = user.FirstName, LastName = user.LastName};
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public UserResponse GetUser(int userId)
        {
            var user = _hyperbookContext.Users.Where(w => w.UserId == userId).FirstOrDefault();

            if (user != null)
            {
                return new UserResponse { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName };
            }
            else
            {
                throw new Exception("User not found");
            }
        }
    }
}
