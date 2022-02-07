using HyperBook.App.Models.ResponseModels;

namespace HyperBook.App.Interfaces
{
    public interface IUsersService
    {
        public UserResponse Login(string email, string password);

        public UserResponse GetUser(int userId);
    }
}
