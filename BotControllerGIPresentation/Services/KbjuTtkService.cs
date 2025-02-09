using BotControllerGIPresentation.GenericService;
using BotControllerGIPresentation.IServices;
using SharedLibrary.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BotControllerGIPresentation.Services
{
    public class KbjuTtkService : GenericService<KbjuTtk>, IKbjuTtkService
    {
        public KbjuTtkService(HttpClient httpClient) : base(httpClient)
        {
            
        }

        public async Task<IEnumerable<KbjuTtk>> GetKbjuTtkByTtkId(int TtkItemId)
        {
            var result = await _httpClient.GetAsync($"/api/{nameof(KbjuTtk)}/GetKbjuTtkByTtkId/{TtkItemId}");
            if (result.IsSuccessStatusCode)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<KbjuTtk>>($"/api/{nameof(KbjuTtk)}/GetKbjuTtkByTtkId/{TtkItemId}");
                return response!;
            }
            else
            {
                Console.WriteLine("Error KbjuTtk Service ClientSide. Return empty enumerable");
                return Enumerable.Empty<KbjuTtk>();
            }
        }
    }
}
