using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusInfo.Infrastructure.Data.Repositories;

public class DriverRepository : RepositoryBase<Driver>, IDriverRepository
{
    public DriverRepository(AppDb appDb) : base(appDb)
    {
    }
}