using BotControllerGIPresentationServer.ApplicationDbContext;
using BotControllerGIPresentationServer.GenericRepositories;
using BotControllerGIPresentationServer.IRepositories.UserIRepository;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Repositories.UserRepos
{
    public class HotcoffeeRepository : GenericRepository<Hotcoffee>, IHotcoffeeRepository
    {
        public HotcoffeeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Hotcoffee> GetHotCoffeeByUserId(int userId) 
        {
            var result = await _context.Hotcoffees.Where(x => x.UserId == userId).FirstOrDefaultAsync();

            if (result is not null) 
            {
                return result;
            }
            else 
            {
                return null;
            }
        }
    }
}
