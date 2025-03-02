using BotControllerGIPresentation.GenericService;
using SharedLibrary.Models;

namespace BotControllerGIPresentation.IServices.ISpotsDimServices
{
    public interface IUserSpotsService : IGenericService<UsersSpot>
    {
        public Task<IEnumerable<UsersSpot>> GetUserSpotsByUserId(int userId);
    }
}
