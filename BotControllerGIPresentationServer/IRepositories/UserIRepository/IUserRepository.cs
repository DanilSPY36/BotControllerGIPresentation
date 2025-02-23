using BotControllerGIPresentationServer.GenericRepositories;
using SharedLibrary.DataTransferObjects;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.IRepositories.UserIRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<string> Login(string email, string password);
        Task<string> Register(string userName, string email, string password);
        Task<User> GetByEmail(string email);
        Task<UserDTO> GetUserDTOByUserId(int UserId);
        Task<User> GetByPhoneNumber(string phoneNumber);
        Task<bool> CheckUserEmail(string userDtoEmail);
    }
}
