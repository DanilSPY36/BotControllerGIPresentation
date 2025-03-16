using Microsoft.JSInterop;

namespace BotControllerGIPresentation.GenericService
{
    public interface ILocalStorageGenericService<Temp>
    {
        Task SetNewItemInLocalStorage(IJSRuntime jSRuntime, string key, Temp item);
        Task UpdateItemInLocalStorage(IJSRuntime jSRuntime, string key, Temp item);
        Task<Temp> GetItemFromLocalStorage(IJSRuntime jSRuntime, string key);
        Task DeleteItemFromLocalStorage(IJSRuntime jSRuntime, string key);
        Task<Temp> CreateDeepCopy(IJSRuntime jSRuntime, Temp item);
        Task ClearLocalStorage(IJSRuntime jSRuntime);
    }
}
