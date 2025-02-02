using BotControllerGIPresentation.GenericService;
using BotControllerGIPresentation.IServices;
using SharedLibrary.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BotControllerGIPresentation.Services
{
    public class TtkService : GenericService<Ttk>, ITtkService
    {
        private readonly HttpClient _httpClient;
        public TtkService(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Ttk>> GetTtkItemsByCategoryId(int categoryId)
        {
            var result = await _httpClient.GetAsync($"/api/{nameof(Ttk)}/GetTtkItemsByCategoryId/{categoryId}");
            if (result.IsSuccessStatusCode)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<Ttk>>($"/api/{nameof(Ttk)}/GetTtkItemsByCategoryId/{categoryId}");
                return response!;
            }
            else
            {
                Console.WriteLine("Error KbjuTtk Service ClientSide. Return empty enumerable");
                return Enumerable.Empty<Ttk>();
            }
        }
        public async Task<IEnumerable<Ttk>> GetTtkItemsByVolumeId(int volumeId)
        {
            var result = await _httpClient.GetAsync($"/api/{nameof(Ttk)}/GetTtkItemsByVolumeId/{volumeId}");
            if (result.IsSuccessStatusCode)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<Ttk>>($"/api/{nameof(Ttk)}/GetTtkItemsByVolumeId/{volumeId}");
                return response!;
            }
            else
            {
                Console.WriteLine("Error KbjuTtk Service ClientSide. Return empty enumerable");
                return Enumerable.Empty<Ttk>();
            }
        }

        public async Task<IEnumerable<Ttk>> GetTtkItemsByContainerId(int containerId)
        {
            var result = await _httpClient.GetAsync($"/api/{nameof(Ttk)}/GetTtkItemsByContainerId/{containerId}");
            if (result.IsSuccessStatusCode)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<Ttk>>($"/api/{nameof(Ttk)}/GetTtkItemsByContainerId/{containerId}");
                return response!;
            }
            else
            {
                Console.WriteLine("Error KbjuTtk Service ClientSide. Return empty enumerable");
                return Enumerable.Empty<Ttk>();
            }
        }

        
    }
}
