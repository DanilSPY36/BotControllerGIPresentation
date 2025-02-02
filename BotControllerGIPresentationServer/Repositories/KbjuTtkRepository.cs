using BotControllerGIPresentationServer.ApplicationDbContext;
using BotControllerGIPresentationServer.GenericRepositories;
using BotControllerGIPresentationServer.IRepositories;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace BotControllerGIPresentationServer.Repositories
{
    public class KbjuTtkRepository : GenericRepository<KbjuTtk>, IKbjuTtkRepository
    {
        private new readonly AppDbContext _context;
        public KbjuTtkRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KbjuTtk>> GetKbjuTtkByTtkId(int ttkItemId)
        {
            var result = await _context.KbjuTtks.Where(x => x.TtkId == ttkItemId).ToListAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Error KbjuTtk Repository: return empty enumerable.");
                return Enumerable.Empty<KbjuTtk>();
            }
        }
    }
}
