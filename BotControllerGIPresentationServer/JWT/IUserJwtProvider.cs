using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.JWT
{
    public interface IUserJwtProvider
    {
        string GenerateToken(User user);
    }
}
