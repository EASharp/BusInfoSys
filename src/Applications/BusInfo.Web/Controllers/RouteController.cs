using AutoMapper;
using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Route = BusInfo.Core.Classes.Route;

namespace BusInfo.Web.Controllers;

public class RouteController : Controller
{
    private readonly IRouteRepository _routeRepository;
    private readonly IMapper _mapper;

    public RouteController(IBusRepository busRepository, IRouteRepository routeRepository, IMapper mapper)
    {
        _routeRepository = routeRepository;
        _mapper = mapper;
    }

    [Route("Route/View/{routeNum}")]
    public async Task<ViewResult> Route(string routeNum)
    {
        var route = await _routeRepository.GetByNumWithPlacesAsync(routeNum);
        return View(route);
    }

    [HttpPost]
    public async Task<OkObjectResult> ManagePlaceInRoute(Place place, string routeNum, bool isAdd)
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
    public async Task<OkResult> DeletePlaceInRoute(string id, string routeNum)
    {
        var route = await _routeRepository.GetByNumWithPlacesAsync(routeNum);
        var place = route.Places.FirstOrDefault(p => p.Id == id);
        route.Places.Remove(place);
        await _routeRepository.SaveChangesAsync();
        return Ok();
    }
    [Route("/Routes")]
    public async Task<ViewResult> RouteList()
    {
        var model= await _routeRepository.ToListWithPlacesAsync();
        return View(model);
    }
[HttpPost]
    public async Task<OkObjectResult> ManageRoute(Route route, bool isAdd)
    {
  
        if (isAdd)
        {
            route.Id = Guid.NewGuid().ToString("N");
            await _routeRepository.AddAsync(route);
            
        }
        else
        {
            var lastRoute = await _routeRepository.GetByIdAsync(route.Id);
            lastRoute.Name = route.Name;
            await  _routeRepository.SaveChangesAsync();
        }
      
        return Ok(route.Id);
    }

    [HttpDelete]
    [Route("/Route/Delete/{id}")]
    public async Task<OkResult> DeleteRoute(string id)
    {
        await _routeRepository.RemoveAsync(id);
        return Ok();
    }
}