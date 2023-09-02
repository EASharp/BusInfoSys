using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusInfo.Infrastructure.Data.Repositories;

public class BusRepository:RepositoryBase<Bus>,IRepositoryBase<Bus>,IBusRepository
{
    public BusRepository(AppDb appDb) : base(appDb)
    {
            
    }

    public Task<Bus> GetByDriverIdAsync(string driverId)
    {
        return set.FirstAsync(bus =>bus.DriverId==driverId); 
    }
}