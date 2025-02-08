using BotControllerGIPresentationServer.GenericRepositories;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.IRepositories.UserIRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<string> Login(string email, string password);
        Task<User> Register(string userName, string email, string password);
        Task<User> GetByEmail(string email);
        Task<User> GetByPhoneNumber(string phoneNumber);
    }
}
