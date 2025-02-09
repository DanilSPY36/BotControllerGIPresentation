using BotControllerGIPresentation.GenericService;
using SharedLibrary.DataTransferObjects;
using SharedLibrary.Models;
using System.Runtime.CompilerServices;

namespace BotControllerGIPresentation.IServices.IUserServices
{
    public interface IUserService :  IGenericService<User>
    { 
        Task<User> GetByEmail(string email);
        Task<User> GetByPhoneNumber(string phoneNumber);
        Task<string> Login(UserLoginDto userLoginDto);
        Task<string> Register(UserRegisterDto userRegisterDto);
        Task<bool> CheckUserEmail(string userDtoEmail);
        Task<bool> Logout();
    }
}
