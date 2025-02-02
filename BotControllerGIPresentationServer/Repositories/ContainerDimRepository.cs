using BotControllerGIPresentationServer.ApplicationDbContext;
using BotControllerGIPresentationServer.GenericRepositories;
using BotControllerGIPresentationServer.IRepositories;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Repositories
{
    public class ContainerDimRepository : GenericRepository<ContainersDim>, IContainerDimRepository
    {
        public ContainerDimRepository(ApplicationDbContext.AppDbContext context) : base(context)
        {
        }

        public override async Task<bool> DeleteAsync(int item_id)
        {
            try
            {
                var entity = _context.ContainersDims.FirstOrDefault(x => x.Id == item_id);
                if (entity is not null)
                {
                    _context.ContainersDims.Remove(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error deleting item is null");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting item: {ex.Message}");
                return false;
            }
        }

    }
}
