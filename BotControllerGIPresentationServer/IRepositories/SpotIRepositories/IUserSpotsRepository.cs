using BotControllerGIPresentation.GenericService;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.IRepositories.SpotIRepositories
{
    public interface IUserSpotsRepository: IGenericService<UsersSpot>
    {
        public Task<IEnumerable<UsersSpot>> GetUserSpotsByUserId(int UserId);
    }
}
