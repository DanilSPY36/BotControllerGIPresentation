using BotControllerGIPresentation.GenericService;
using SharedLibrary.Models;

namespace BotControllerGIPresentation.IServices
{
    public interface ITtkService : IGenericService<Ttk>
    {
        Task<IEnumerable<Ttk>> GetTtkItemsByCategoryId(int categoryId);
        Task<IEnumerable<Ttk>> GetTtkItemsByVolumeId(int volumeId);
        Task<IEnumerable<Ttk>> GetTtkItemsByContainerId(int containerId);
    }
}
