using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusInfo.Infrastructure.Data.Repositories;

public class RouteRepository : RepositoryBase<Route>, IRouteRepository
{
    public RouteRepository(AppDb appDb) : base(appDb)
    {
    }

    public Task<Route> GetByNumWithPlacesAsync(int num)
    {
        return set.Include(p => p.Places).FirstAsync(p => p.Number == num);
    }

    public Task<Route> GetByNumberAsync(int number)
    {
        return set.IgnoreAutoIncludes().FirstAsync(p => p.Number == number);
    }
}