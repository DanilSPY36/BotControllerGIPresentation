using BotControllerGIPresentation.GenericService;
using SharedLibrary.Models;

namespace BotControllerGIPresentation.IServices.IUserServices
{
    public interface IHotcoffeeService : IGenericService<Hotcoffee> 
    {
        public Task<Hotcoffee> GetHotCoffeeByUserId(int userId);
        public Task<bool> DelAllItemsByUserId(int userId);
    }
}
