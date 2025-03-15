using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BotControllerGIPresentation.GenericService
{
    public class LocalStorageGenericService<Temp> : ILocalStorageGenericService<Temp> where Temp : class
    {
        private readonly HttpClient httpClient;

        public LocalStorageGenericService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task SetNewItemInLocalStorage(IJSRuntime jSRuntime, string key, Temp item)
        {
            string itemJSON = System.Text.Json.JsonSerializer.Serialize(item);
            await jSRuntime.InvokeVoidAsync("localStorage.setItem", key, itemJSON);
        }

        public async Task UpdateItemInLocalStorage(IJSRuntime jSRuntime, string key, Temp item)
        {
            await SetNewItemInLocalStorage(jSRuntime, key, item); // Переиспользуем метод для обновления
        }

        public async Task<Temp> GetItemFromLocalStorage(IJSRuntime jSRuntime, string key)
        {
            var itemJson = await jSRuntime.InvokeAsync<string>("localStorage.getItem", key);
            if (itemJson is not null)
            {
                var itemFromLocalStorage = System.Text.Json.JsonSerializer.Deserialize<Temp>(itemJson);
                return itemFromLocalStorage!;
            }
            else
            {
                return null!;
            }
        }

        public async Task<Temp> CreateDeepCopy(IJSRuntime jSRuntime, Temp item)
        {
            string itemJSON = System.Text.Json.JsonSerializer.Serialize(item);
            await jSRuntime.InvokeVoidAsync("localStorage.setItem", typeof(Temp).Name, itemJSON);
            var itemJson = await jSRuntime.InvokeAsync<string>("localStorage.getItem", typeof(Temp).Name);
            var itemFromLocalStorage = System.Text.Json.JsonSerializer.Deserialize<Temp>(itemJson);
            return itemFromLocalStorage!;
        }

        public async Task DeleteItemFromLocalStorage(IJSRuntime jSRuntime, string key)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
