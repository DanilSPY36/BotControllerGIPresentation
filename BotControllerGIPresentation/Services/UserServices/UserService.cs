using BotControllerGIPresentation.GenericService;
using BotControllerGIPresentation.IServices.IUserServices;
using SharedLibrary.DataTransferObjects;
using SharedLibrary.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace BotControllerGIPresentation.Services.UserServices
{
    public class UserService : GenericService<User>, IUserService
    { 
        public UserService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            var response = await _httpClient.GetAsync($"api/User/GetByEmail?email={email}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<User>(jsonResponse);
                if (user != null) 
                {
                    return user;
                }
                else 
                {
                    return null!;
                }
            }
            else
            {
                return null!;
            }
        }

        public async Task<User> GetByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(UserLoginDto userLoginDto) 
        {

            var response = await _httpClient.PostAsJsonAsync($"api/User/Login", userLoginDto);

            if (response.IsSuccessStatusCode) 
            {
                var token = await response.Content.ReadAsStringAsync();
                return token;
            }
            else
            {
                return string.Empty;
            }
        }
        public async Task<string> Register(UserRegisterDto userRegisterDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/User/Register", userRegisterDto);
            if (response.IsSuccessStatusCode) 
            {
                var token = await response.Content.ReadAsStringAsync();
                return token;
            }
            else 
            {
                return string.Empty;
            }
        }
    }
}
