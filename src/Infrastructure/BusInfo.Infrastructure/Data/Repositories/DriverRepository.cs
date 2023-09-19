using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusInfo.Infrastructure.Data.Repositories;

public class DriverRepository : RepositoryBase<Driver>, IDriverRepository
{
    public DriverRepository(AppDb appDb) : base(appDb)
    {
    }

    public async Task<Driver?> GetByLogPasswordAsync(string login, string password)
    {
        var driver = await set.FirstOrDefaultAsync(opt => opt.DriverPassword == password && opt.DriverLogin == login);
        return driver;
        
    }
}