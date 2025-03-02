using BotControllerGIPresentation.GenericService;
using BotControllerGIPresentationServer.GenericRepositories;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.IRepositories.SpotIRepositories
{
    public interface IUsersSpotRepository: IGenericRepository<UsersSpot>
    {
        public Task<IEnumerable<UsersSpot>> GetUserSpotsByUserId(int UserId);
    }
}
