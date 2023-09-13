using AutoMapper;
using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BusInfo.Web.Controllers;

public class RouteController : Controller
{
    private readonly IBusRepository _busRepository;
    private readonly IRouteRepository _routeRepository;
    private readonly IMapper _mapper;

    public RouteController(IBusRepository busRepository, IRouteRepository routeRepository, IMapper mapper)
    {
        _busRepository = busRepository;
        _routeRepository = routeRepository;
        _mapper = mapper;
    }

    [Route("Route/View/{routeNum}")]
    public async Task<ViewResult> Route(int routeNum)
    {
        var route = await _routeRepository.GetByNumWithPlacesAsync(routeNum);
        return View(route);
    }

    [HttpPost]
    public async Task<OkObjectResult> ManagePlaceInRoute(Place place, int routeNum, bool isAdd)
    {
        var route = await _routeRepository.GetByNumWithPlacesAsync(routeNum);
        if (isAdd)
        {
            place.Id = Guid.NewGuid().ToString("N");
            route.Places.Add(place);
        }
        else
        {
            var lastPlace = route.Places.FirstOrDefault(p => p.Id == place.Id);
            _mapper.Map(place, lastPlace);
          
        }
        await _routeRepository.SaveChangesAsync();
        return Ok(place.Id);
    }

    [HttpDelete]
    [Route("/Route/DeletePlaceInRoute/{routeNum}/{id}")]
    public async Task<OkResult> DeletePlaceInRoute(string id, int routeNum)
    {
        var route = await _routeRepository.GetByNumWithPlacesAsync(routeNum);
        var place = route.Places.FirstOrDefault(p => p.Id == id);
        route.Places.Remove(place);
        await _routeRepository.SaveChangesAsync();
        return Ok();
    }
}