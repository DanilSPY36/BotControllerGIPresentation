using BotControllerGIPresentationServer.ApplicationDbContext;
using BotControllerGIPresentationServer.GenericRepositories;
using BotControllerGIPresentationServer.IRepositories.SpotIRepositories;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Repositories.SpotRepositories
{
    public class SpotsDimRepository : GenericRepository<SpotsDim>, ISpotsDimRepository
    {
        public SpotsDimRepository(AppDbContext context) : base(context)
        {
        }
    }
}
