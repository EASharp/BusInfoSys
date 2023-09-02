using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusInfo.Infrastructure.Data.Repositories;

public class PlaceRepository:RepositoryBase<Place>, IPlaceRepository   
    
{
    public PlaceRepository(AppDb dbContext) : base(dbContext)
    {
    }
    
}