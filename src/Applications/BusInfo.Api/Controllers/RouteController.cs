using System.Runtime.CompilerServices;
using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Route = BusInfo.Core.Classes.Route;

namespace BusInfo.Api.Controllers;
[Route("api/[controller]")]
public class RouteController : Controller
{
    private readonly IRouteRepository _routeRepository;
    
    public RouteController(IRouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
     
    }
    [HttpGet("GetRoute")]
    public Task<Route> GetRoute(string routeNum)
    {
        return _routeRepository.GetByNumWithPlacesAsync(routeNum);
    } 
    [HttpGet("GetRoutesNum")]
    public Task<List<Route>> GetRoutesNum()
    {
        return _routeRepository.ToListAsync();
        
    }
}