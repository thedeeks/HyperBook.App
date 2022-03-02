using HyperBook.App.Models.ResponseModels;
using HyperBook.App.Models.PutModels;
using System;

namespace HyperBook.App.Interfaces
{
    public interface IUsersService
    {

        /// <summary>
        /// Logs the user in to the application
        /// </summary>        
        /// <param name="email">user email</param>
        /// <param name="password">user password</param>
        /// <returns>UserId, Email, FirstName, LastName, Street, City, State, Zip, Phone</returns>
        UserResponse Login(string email, string password);


        /// <summary>
        /// Returns User Info
        /// </summary>        
        /// <returns>Emai, FirstName, LastName</returns>
        UserResponse GetAccountInfo(Guid userId);


        /// <summary>
        /// Updates an existing User
        /// </summary>
        /// <param name="user">User Object</param>
        void UpdateUser(UserUpdateModel user);
    }
}
