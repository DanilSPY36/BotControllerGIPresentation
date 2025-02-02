using BotControllerGIPresentationServer.Controllers;
using BotControllerGIPresentationServer.GenericRepositories;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.IRepositories
{
    public interface ITtkRepository : IGenericRepository<Ttk>
    {
        Task<IEnumerable<Ttk>> GetTtkItemsByCategoryId(int itemId);
        Task<IEnumerable<Ttk>> GetTtkItemsByVolumeId(int volumeId);
        Task<IEnumerable<Ttk>> GetTtkItemsByContainerId(int containerId);


    }
}
