using BotControllerGIPresentationServer.GenericRepositories;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.IRepositories
{
    public interface ICategoriesDimRepository : IGenericRepository<CategoriesDim>
    {
        new Task<bool> DeleteAsync(int item_id);
    }
}
