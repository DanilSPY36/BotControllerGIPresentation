using BotControllerGIPresentationServer.GenericRepositories;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.IRepositories
{
    public interface IKbjuTtkRepository: IGenericRepository<KbjuTtk>
    {
        public Task<IEnumerable<KbjuTtk>> GetKbjuTtkByTtkId(int ttkItemId);
     }
}
