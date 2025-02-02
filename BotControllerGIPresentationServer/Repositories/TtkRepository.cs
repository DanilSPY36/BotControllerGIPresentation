using BotControllerGIPresentationServer.ApplicationDbContext;
using BotControllerGIPresentationServer.GenericRepositories;
using BotControllerGIPresentationServer.IRepositories;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using System.Xml.Linq;

namespace BotControllerGIPresentationServer.Repositories
{
    public class TtkRepository : GenericRepository<Ttk>, ITtkRepository
    {
        public TtkRepository(ApplicationDbContext.AppDbContext context) : base(context)
        {
        }


        public override async Task<IEnumerable<Ttk>> GetAllAsync()
        {
            var result = await _context.Ttks.Include(x => x.Category).Include(x => x.Container).Include(x => x.KbjuTtks).ToListAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Error Repository: return empty enumerable.");
                return Enumerable.Empty<Ttk>();
            }
        }
        public async Task<IEnumerable<Ttk>> GetTtkItemsByCategoryId(int itemId)
        {
            var result = await _context.Ttks.Include(x => x.Category).Include(x => x.Volume).Include(x => x.Container).Include(x => x.KbjuTtks).Where(x => x.CategoryId == itemId).ToListAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Error Repository: return empty enumerable.");
                return Enumerable.Empty<Ttk>();
            }
        }
        public async Task<IEnumerable<Ttk>> GetTtkItemsByVolumeId(int volumeId)
        {
            var result = await _context.Ttks.Include(x => x.Category).Include(x => x.Volume).Include(x => x.Container).Include(x => x.KbjuTtks).Where(x => x.VolumeId == volumeId).ToListAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Error Repository: return empty enumerable.");
                return Enumerable.Empty<Ttk>();
            }
        }
        public async Task<IEnumerable<Ttk>> GetTtkItemsByContainerId(int containerId)
        {
            var result = await _context.Ttks.Include(x => x.Category).Include(x => x.Volume).Include(x => x.Container).Include(x => x.KbjuTtks).Where(x => x.ContainerId == containerId).ToListAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Error Repository: return empty enumerable.");
                return Enumerable.Empty<Ttk>();
            }
        }


        public override async Task<bool> DeleteAsync(int item_id)
        {
            try
            {
                var entity = await GetByIDAsync(item_id);
                _context.Ttks.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting item: {ex.Message}");
                return false;
            }
        }
        public override async Task<Ttk> GetByIDAsync(int item_id)
        {
            try
            {
                var result = await _context.Ttks.Include(x => x.KbjuTtks).FirstOrDefaultAsync(x => x.Id == item_id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Error GenericRepository: return Temp  null");
                    return null!;
                }
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null!;
            }
        }
    }
}
