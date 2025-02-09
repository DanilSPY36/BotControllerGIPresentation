using BotControllerGIPresentationServer.ApplicationDbContext;
using BotControllerGIPresentationServer.Auth;
using BotControllerGIPresentationServer.GenericRepositories;
using BotControllerGIPresentationServer.IRepositories.UserIRepository;
using BotControllerGIPresentationServer.JWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Repositories.UserRepos
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserJwtProvider _userJwtProvider;
        public UserRepository(AppDbContext context, IPasswordHasher passwordHasher, IUserJwtProvider userJwtProvider) : base(context)
        {
            _passwordHasher = passwordHasher;
            _userJwtProvider = userJwtProvider;
        }

        public async Task<string> Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            var user = new User()
            {
                Name = userName,
                Email = email,
                PasswordHash = hashedPassword
            };
            var result = await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            if (result is not null) 
            {
                var JwtToken = _userJwtProvider.GenerateToken(result.Entity);
                return JwtToken;
            }
            else
            {
                return string.Empty;
            }
        }

        public async  Task<string> Login(string email, string password)
        {
            var userFromDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (userFromDb is not null) 
            {
                var result = _passwordHasher.Verify(password, userFromDb.PasswordHash);
                if(result == true) 
                {
                    var JwtToken = _userJwtProvider.GenerateToken(userFromDb);
                    return JwtToken;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
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
        public async Task<bool> CheckUserEmail(string userDtoEmail) 
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDtoEmail);
            if(user is not null) 
            {
                return false;
            }
            else {  return true; }
        }
        public Task<User> GetByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
