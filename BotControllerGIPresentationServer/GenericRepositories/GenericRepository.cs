using BotControllerGIPresentationServer.ApplicationDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BotControllerGIPresentationServer.GenericRepositories
{
    public class GenericRepository<Temp> : IGenericRepository<Temp> where Temp : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context) => _context = context;


        public virtual async Task<IEnumerable<Temp>> GetAllAsync()
        {
            DbSet<Temp> _dbSet = _context.Set<Temp>();
            var result = await _dbSet.ToListAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Error Repository: return empty enumerable.");
                return Enumerable.Empty<Temp>();
            }
        }

        public virtual async Task<Temp> GetByIDAsync(int item_id)
        {
            DbSet<Temp> _dbSet = _context.Set<Temp>();

            try
            {
                var result = await _dbSet.FindAsync(item_id);
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

        public virtual async Task<Temp> AddAsync(Temp item)
        {
            DbSet<Temp> _dbSet = _context.Set<Temp>();
            try
            {
                if (!_context.Database.CanConnect())
                {
                    Console.WriteLine("Ошибка подключения к базе данных.");
                    return null!;
                }
                var newItem = await _dbSet.AddAsync(item);
                await _context.SaveChangesAsync();
                return newItem.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding item: {ex.Message}");
                return null!;
            }
        }

        public virtual async Task<bool> DeleteAsync(int item_id)
        {
            DbSet<Temp> _dbSet = _context.Set<Temp>();
            try
            {
                var entity = await GetByIDAsync(item_id);
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting item: {ex.Message}");
                return false;
            }
        }

        public virtual async Task<Temp> UpdateAsync(Temp item)
        {
            DbSet<Temp> _dbSet = _context.Set<Temp>();
            try
            {
                var x = _dbSet.Update(item);
                var prop = x.Properties.First();
                await _context.SaveChangesAsync();
                var updatedItem = await _dbSet.FindAsync(prop.CurrentValue);
                if (updatedItem != null)
                {
                    return updatedItem;
                }
                else
                {
                    return null!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating item: {ex.Message}");
                return null!;
            }
        }
    }
}
