using BotControllerGIPresentationServer.ApplicationDbContext;
using BotControllerGIPresentationServer.GenericRepositories;
using BotControllerGIPresentationServer.IRepositories.UserIRepository;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Repositories.UserRepos
{
    public class HotcoffeeRepository : GenericRepository<Hotcoffee>, IHotcoffeeRepository
    {
        public HotcoffeeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
