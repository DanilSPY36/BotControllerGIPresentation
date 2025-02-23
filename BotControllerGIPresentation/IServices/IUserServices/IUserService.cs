using BotControllerGIPresentation.GenericService;
using SharedLibrary.DataTransferObjects;
using SharedLibrary.Models;
using System.Runtime.CompilerServices;

namespace BotControllerGIPresentation.IServices.IUserServices
{
    public interface IUserService :  IGenericService<User>
    { 
        Task<string> Login(UserLoginDto userLoginDto);
        Task<string> Register(UserRegisterDto userRegisterDto);
        Task<UserDTO> GetUserDTOByUserId(int UserId);
        Task<bool> CheckUserEmail(string userDtoEmail);
        Task<bool> Logout();
    }
}
