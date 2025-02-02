using BotControllerGIPresentationServer.GenericRepositories;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.IRepositories.UserIRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByPhoneNumber(string phoneNumber);
    }
}
