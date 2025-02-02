using BotControllerGIPresentationServer.ApplicationDbContext;
using BotControllerGIPresentationServer.GenericRepositories;
using BotControllerGIPresentationServer.IRepositories.UserIRepository;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Repositories.UserRepos
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null!;
            }

            var userFromDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (userFromDb == null)
            { 
                return null!;
            }
            else 
            {
                return userFromDb;
            }
        }

        public Task<User> GetByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
