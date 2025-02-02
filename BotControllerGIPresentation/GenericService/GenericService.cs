using Radzen;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace BotControllerGIPresentation.GenericService
{
    public class GenericService<Temp>: IGenericService<Temp> where Temp : class
    {
        protected readonly HttpClient _httpClient;

        public GenericService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public virtual async Task<IEnumerable<Temp>> GetAllAsync()
        {
            Type tempType = typeof(Temp);
            var result = await _httpClient.GetAsync($"/api/{tempType.Name}/GetAll");
            if (result.IsSuccessStatusCode)
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<Temp>>($"/api/{tempType.Name}/GetAll");
                return response!;
            }
            else
            {
                Console.WriteLine("Error Service ClientSide. Return empty enumerable");
                return Enumerable.Empty<Temp>();
            }
        }

        public virtual async Task<Temp> GetByIDAsync(int item_id)
        {
            Type tempType = typeof(Temp);

            var result = await _httpClient.GetAsync($"/api/{tempType.Name}/GetById/{item_id}");

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<Temp>();
                return response!;
            }
            else
            {
                Console.WriteLine("Error Service ClientSide. Return null Temp");
                return null!;
            }
        }

        public virtual async Task<Temp> AddAsync(Temp item)
        {
            Type tempType = typeof(Temp);
            var result = await _httpClient.PostAsJsonAsync($"/api/{tempType.Name}/Add", item);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadFromJsonAsync<Temp>();
                return content!;
            }
            else
            {
                Console.WriteLine("Error adding item: " + result.StatusCode);
                return null!;
            }
        }

        public virtual async Task<bool> DeleteAsync(int item_id)
        {
            Type tempType = typeof(Temp);
            var result = await _httpClient.DeleteAsync($"/api/{tempType.Name}/Delete/{item_id}");
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error deleting item: " + result.StatusCode);
                return false;
            }

        }

        public virtual async Task<Temp> UpdateAsync(Temp item)
        {
            Type tempType = typeof(Temp);
            var result = await _httpClient.PutAsJsonAsync($"/api/{tempType.Name}/Update", item);
            if (result.IsSuccessStatusCode)
            {
                var updatedItem = await result.ReadAsync<Temp>();
                return updatedItem;
            }
            else
            {
                Console.WriteLine("Error updating item: " + result.StatusCode);
                return null!;
            }
        }

    }
}
