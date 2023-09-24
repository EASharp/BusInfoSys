using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusInfo.Infrastructure.Data.Repositories;

public class BusRepository : RepositoryBase<Bus>, IRepositoryBase<Bus>, IBusRepository
{
    public BusRepository(AppDb appDb) : base(appDb)
    {
    }

    public Task<Bus> GetByDriverIdAsync(string driverId)
    {
        return set.FirstAsync(bus => bus.DriverId == driverId);
    }

    public Task<Bus> GetWithPlaces(string busId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Bus>> GetEnabled()
    {
        return set.Where(bus => bus.Enabled == true).ToListAsync();
    }

    public async Task<bool> IsDriverIdExistAsync(string driverId)
    {
        if (await set.FirstOrDefaultAsync(bus => bus.DriverId == driverId)==null)
            return false;
        return true;
    }
}