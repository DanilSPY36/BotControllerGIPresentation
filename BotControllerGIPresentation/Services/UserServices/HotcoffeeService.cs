using BotControllerGIPresentation.GenericService;
using BotControllerGIPresentation.IServices.IUserServices;
using SharedLibrary.Models;
using System.Net.Http.Json;

namespace BotControllerGIPresentation.Services.UserServices
{
    public class HotcoffeeService : GenericService<Hotcoffee>, IHotcoffeeService
    {
        public HotcoffeeService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<Hotcoffee> GetHotCoffeeByUserId(int userId) 
        {
            var request = await _httpClient.GetAsync($"api/Hotcoffee/GetHotCoffeeByUserId/{userId}");
            if (request.IsSuccessStatusCode) 
            {
                var result = await request.Content.ReadFromJsonAsync<Hotcoffee?>();
                if(result is not null) 
                {
                    return result;
                }
                else 
                {
                    return null;
                }
            }
            else 
            {
                return null;
            }
        }
    }
}
