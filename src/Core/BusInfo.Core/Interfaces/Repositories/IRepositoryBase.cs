namespace BusInfo.Core.Interfaces.Repositories;

public interface IRepositoryBase<TPojo> where TPojo : ITypeBase
{
    Task<TPojo> GetByIdAsync(string id);
    Task<bool> ExistAsync(string id);
    Task AddAsync(TPojo pojo);
    Task RemoveAsync(string id);
    public Task<TPojo> UpdateAsync(TPojo pojo);
  
    Task<List<TPojo>> ToListAsync();
    Task<int> SaveChangesAsync();
}