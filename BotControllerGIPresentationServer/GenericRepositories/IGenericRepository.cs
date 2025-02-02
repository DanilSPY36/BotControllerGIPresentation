namespace BotControllerGIPresentationServer.GenericRepositories
{
    public interface IGenericRepository<Temp>
    {
        Task<IEnumerable<Temp>> GetAllAsync();
        Task<Temp> GetByIDAsync(int item_id);
        Task<Temp> AddAsync(Temp item);
        Task<Temp> UpdateAsync(Temp item);
        Task<bool> DeleteAsync(int item_id);
    }
}
