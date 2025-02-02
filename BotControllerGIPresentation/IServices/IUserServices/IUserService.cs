using BotControllerGIPresentation.GenericService;
using SharedLibrary.Models;
using System.Runtime.CompilerServices;

namespace BotControllerGIPresentation.IServices.IUserServices
{
    public interface IUserService :  IGenericService<User>
    { 
        Task<User> GetByEmail(string email);
        Task<User> GetByPhoneNumber(string phoneNumber);

        Task Register(string userName, string email, string passwordHash);
    }
}
