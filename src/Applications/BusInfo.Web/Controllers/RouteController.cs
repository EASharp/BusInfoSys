using System.Globalization;
using System.Net;
using AutoMapper;
using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Route = BusInfo.Core.Classes.Route;

namespace BusInfo.Web.Controllers;

public class RouteController:Controller
{
    
    private readonly IRouteRepository _routeRepository;
    private IMapper _mapper;
    public RouteController(IBusRepository busRepository, IRouteRepository routeRepository,IMapper mapper)
    {
        _routeRepository = routeRepository;
        _mapper = mapper;
    }
    [Route("Route/View/{routeNum}")]
    public async Task<ViewResult> Route(int routeNum)
    {   var route = await _routeRepository.GetByNumWithPlacesAsync(routeNum);
        return View(route);
    }
    
    [HttpPost]
    public async Task<OkResult> UpdateRoute(Place place,int routeNum)
    {
        var route = await _routeRepository.GetByNumWithPlacesAsync(routeNum);
        var lastPlace = route.Places.FirstOrDefault(p => p.Id == place.Id);
        _mapper.Map(place, lastPlace);
        await _routeRepository.SaveChangesAsync();
        
        return Ok();
    }

}