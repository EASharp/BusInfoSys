using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using BusInfo.Infrastructure.Data;
using BusInfo.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BusInfo.Infrastructure;

public static class Loader
{
    public static void AddInfrastructureModule(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddTransient<AppDb>();
        services.AddScoped(typeof(IBusRepository),typeof(BusRepository));
        services.AddScoped(typeof(IPlaceRepository),typeof(PlaceRepository));
        services.AddScoped(typeof(IDriverRepository),typeof(DriverRepository));
    }
}