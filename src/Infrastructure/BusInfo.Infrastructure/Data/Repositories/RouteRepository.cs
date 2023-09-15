using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusInfo.Infrastructure.Data.Repositories;

public class RouteRepository : RepositoryBase<Route>, IRouteRepository
{
    public RouteRepository(AppDb appDb) : base(appDb)
    {
    }

    public Task<Route> GetByNumWithPlacesAsync(string name)
    {
        return set.Include(p => p.Places).FirstAsync(p => p.Name == name);
    }

    public Task<List<Route>> ToListWithPlacesAsync()
    {
        return Task.FromResult(set.Include(p => p.Places).ToList());
    }

    public Task<Route> GetByNumberAsync(string name)
    {
        return set.IgnoreAutoIncludes().FirstAsync(p => p.Name == name);
    }
}