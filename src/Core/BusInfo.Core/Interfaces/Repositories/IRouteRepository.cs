using BusInfo.Core.Classes;

namespace BusInfo.Core.Interfaces.Repositories;

public interface IRouteRepository : IRepositoryBase<Route>
{
    public Task<Route> GetByNumWithPlacesAsync(string routeName);
    public Task<List<Route>> ToListWithPlacesAsync();
}