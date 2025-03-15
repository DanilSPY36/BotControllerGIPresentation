using BotControllerGIPresentation.GenericService;
using BotControllerGIPresentation.IServices.IUserServices;
using SharedLibrary.Models;

namespace BotControllerGIPresentation.Services.UserServices
{
    public class HotcoffeeService : GenericService<Hotcoffee>, IHotcoffeeService
    {
        public HotcoffeeService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
