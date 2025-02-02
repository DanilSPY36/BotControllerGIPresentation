using BotControllerGIPresentationServer.GenericRepositories;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.IRepositories
{
    public interface IContainerDimRepository : IGenericRepository<ContainersDim>
    {
        new Task<bool> DeleteAsync(int item_id);
    }
}
