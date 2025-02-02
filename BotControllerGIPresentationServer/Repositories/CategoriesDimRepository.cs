using BotControllerGIPresentationServer.ApplicationDbContext;
using BotControllerGIPresentationServer.GenericRepositories;
using BotControllerGIPresentationServer.IRepositories;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Repositories
{
    public class CategoriesDimRepository : GenericRepository<CategoriesDim>, ICategoriesDimRepository
    {
        public CategoriesDimRepository(ApplicationDbContext.AppDbContext context) : base(context)
        {
        }



        public override async Task<bool> DeleteAsync(int item_id)
        {
            try
            {
                var entity = _context.CategoriesDims.Include(x => x.Ttks).ThenInclude(x => x.KbjuTtks).FirstOrDefault(x => x.Id == item_id);
                if (entity is not null)
                {
                    _context.CategoriesDims.Remove(entity);
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
