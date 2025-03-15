using Blazor.SubtleCrypto;
using BotControllerGIPresentation.IServices.IUserServices;
using Microsoft.JSInterop;
using SharedLibrary.DataTransferObjects;

namespace BotControllerGIPresentation.GenericService
{
    public interface IHotCoffeeMaker<Temp> where Temp : class
    {
        public Task<bool> SetHotCoffe(IHotcoffeeService service, ICryptoService cryptoService, ILocalStorageGenericService<string> LocalStorageServiceTest, IJSRuntime jsRuntime, UserLoginDto user);
        public Task<bool> MakeHotCoffe(IHotcoffeeService service, ICryptoService cryptoService, ILocalStorageGenericService<string> LocalStorageServiceTest, IJSRuntime jsRuntime, Temp item, int userId, string keyName = "hotCoffee");
        public Task<Temp> MakeColdCoffe(IHotcoffeeService service, ICryptoService cryptoService, ILocalStorageGenericService<string> LocalStorageServiceTest, IJSRuntime jsRuntime, Temp item, int userId, string keyName = "hotCoffee");
    }
}
