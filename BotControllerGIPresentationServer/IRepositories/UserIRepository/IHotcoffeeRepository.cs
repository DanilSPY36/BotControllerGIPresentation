using BotControllerGIPresentationServer.GenericRepositories;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.IRepositories.UserIRepository
{
    public interface IHotcoffeeRepository : IGenericRepository<Hotcoffee>
    {
        public Task<Hotcoffee> GetHotCoffeeByUserId(int userId);
        public Task<bool> DelAllItemsByUserId(int userId);
    }
}
