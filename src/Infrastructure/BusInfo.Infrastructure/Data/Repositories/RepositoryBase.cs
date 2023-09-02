using BusInfo.Core.Interfaces;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusInfo.Infrastructure.Data.Repositories;

public  class RepositoryBase<TPojo>:IRepositoryBase<TPojo> where TPojo: class, ITypeBase
{
    protected readonly AppDb AppDb;
    protected  readonly DbSet<TPojo> set;

    protected RepositoryBase(AppDb appDb)
    {
        set = appDb.Set<TPojo>();
        AppDb = appDb;
    }
    
    public Task<TPojo> GetByIdAsync(string id)
    {
       return  set.FirstAsync(p => p.Id == id);
    }

    public Task<bool> ExistAsync(string id)
    {
        return set.AnyAsync(@base =>@base.Id== id);
    }

    public Task AddAsync(TPojo pojo)
    {
        return Task.FromResult(set.Add(pojo));
    }

    public async Task RemoveAsync(string id)
    {
      
        set.Remove(await set.FirstAsync(s=>s.Id==id));
        await SaveChangesAsync();

    }

    public Task<List<TPojo>> ToListAsync()
    {
        return set.ToListAsync();
    }
    public async Task<TPojo> UpdateAsync(TPojo pojo)
    {
        set.Update(pojo);
        await SaveChangesAsync();
        return pojo;
        
    }

    private Task<int> SaveChangesAsync()
    {
        return AppDb.SaveChangesAsync();
    
}
}