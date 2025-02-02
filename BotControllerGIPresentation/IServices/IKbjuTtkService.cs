using BotControllerGIPresentation.GenericService;
using SharedLibrary.Models;

namespace BotControllerGIPresentation.IServices
{
    public interface IKbjuTtkService : IGenericService<KbjuTtk>
    {
        public Task<IEnumerable<KbjuTtk>> GetKbjuTtkByTtkId(int TtkItemId);
    }
}
