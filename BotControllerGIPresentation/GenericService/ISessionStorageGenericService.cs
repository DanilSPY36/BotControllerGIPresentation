using Microsoft.JSInterop;

namespace BotControllerGIPresentation.GenericService
{
    public interface ISessionStorageGenericService<Temp>
    {
        Task SetNewItemInSessionStorage(IJSRuntime jSRuntime, Temp item);
        Task UpdateItemInSessionStorage(IJSRuntime jSRuntime, Temp item);
        Task<Temp> GetItemFromSessionStorage(IJSRuntime jSRuntime, Temp item);
        Task DeleteItemFromSessionStorage(IJSRuntime jSRuntime, Temp item);
        Task<Temp> CreateDeepCopy(IJSRuntime jSRuntime, Temp item);

    }
}
