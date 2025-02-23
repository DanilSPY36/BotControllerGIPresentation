using BotControllerGIPresentationServer.ApplicationDbContext;
using BotControllerGIPresentationServer.GenericRepositories;
using BotControllerGIPresentationServer.IRepositories.SpotIRepositories;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Repositories.SpotRepositories
{
    public class UserSpotsRepository : GenericRepository<UsersSpot>, IUserSpotsRepository
    {
        public UserSpotsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UsersSpot>> GetUserSpotsByUserId(int UserId)
        {
            var result = await _context.UsersSpots.Where(x => x.UserId == UserId).ToListAsync();
            if(result is not null) 
            {
                return result;
            }
            else 
            {
                return Enumerable.Empty<UsersSpot>();
            }
        }
    }
}
