using Microsoft.JSInterop;

namespace BotControllerGIPresentation.GenericService
{
    public class SessionStorageGenericService<Temp> : ISessionStorageGenericService<Temp> where Temp : class
    {
        private readonly HttpClient httpClient;

        public SessionStorageGenericService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task SetNewItemInSessionStorage(IJSRuntime jSRuntime, Temp item)
        {
            string itemJSON = System.Text.Json.JsonSerializer.Serialize(item);
            await jSRuntime.InvokeVoidAsync("sessionStorage.setItem", typeof(Temp).Name, itemJSON);
        }

        public async Task UpdateItemInSessionStorage(IJSRuntime jSRuntime, Temp item)
        {
            await SetNewItemInSessionStorage(jSRuntime, item); // Переиспользуем метод для обновления
        }

        public async Task<Temp> GetItemFromSessionStorage(IJSRuntime jSRuntime, Temp item)
        {
            var itemJson = await jSRuntime.InvokeAsync<string>("sessionStorage.getItem", typeof(Temp).Name);
            if (itemJson is not null)
            {
                var itemFromSessionStorage = System.Text.Json.JsonSerializer.Deserialize<Temp>(itemJson);
                return itemFromSessionStorage!;
            }
            else
            {
                return null!;
            }
        }
        public async Task<Temp> CreateDeepCopy(IJSRuntime jSRuntime, Temp item)
        {
            string itemJSON = System.Text.Json.JsonSerializer.Serialize(item);
            await jSRuntime.InvokeVoidAsync("sessionStorage.setItem", typeof(Temp).Name, itemJSON);
            var itemJson = await jSRuntime.InvokeAsync<string>("sessionStorage.getItem", typeof(Temp).Name);
            var itemFromSessionStorage = System.Text.Json.JsonSerializer.Deserialize<Temp>(itemJson);
            return itemFromSessionStorage!;
        }
        public async Task DeleteItemFromSessionStorage(IJSRuntime jSRuntime, Temp item)
        {
            await jSRuntime.InvokeVoidAsync("sessionStorage.removeItem", typeof(Temp).Name);
        }
    }
}
