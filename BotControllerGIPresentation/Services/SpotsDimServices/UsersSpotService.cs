using BotControllerGIPresentation.GenericService;
using BotControllerGIPresentation.IServices.ISpotsDimServices;
using SharedLibrary.Models;
using System.Net.Http.Json;

namespace BotControllerGIPresentation.Services.SpotsDimServices
{
    public class UsersSpotService : GenericService<UsersSpot>, IUserSpotsService
    {
        public UsersSpotService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<IEnumerable<UsersSpot>> GetUserSpotsByUserId(int userId)
        {
            var response = await _httpClient.GetAsync($"/api/UsersSpot/GetUserSpotsByUserId/{userId}");
            if (response.IsSuccessStatusCode) 
            {
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<UsersSpot>>();
                if (result is not null) 
                {
                    return result; 
                }
                else 
                {
                    return Enumerable.Empty<UsersSpot>();
                }
            }
            else 
            {
                return Enumerable.Empty<UsersSpot>();
            }
        }
    }
}
