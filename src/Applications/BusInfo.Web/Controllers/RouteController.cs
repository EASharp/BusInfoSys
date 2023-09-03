using System.Globalization;
using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BusInfo.Web.Controllers;

public class RouteController:Controller
{
    
    private IRouteRepository _routeRepository;
    public RouteController(IBusRepository busRepository, IRouteRepository routeRepository)
    {
     
        _routeRepository = routeRepository;
    }
    [Route("Route/{routeNum}")]
    public async Task<ViewResult> Route(int routeNum)
    {
        var route =await _routeRepository.GetByNumWithPlacesAsync(routeNum);
        route.Places.Add(new Place{PlaceName = "Вокзал",Id = Guid.NewGuid().ToString("D"),Latitude = 59.913888.ToString(CultureInfo.InvariantCulture),Longitude = 30.33.ToString(CultureInfo.InvariantCulture)});
        route =await _routeRepository.UpdateAsync(route);
        return View(route);
    }
}