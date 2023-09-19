using System.Diagnostics;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using BusInfo.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace BusInfo.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBusRepository _busRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IRouteRepository _routeRepository;
    private readonly IPlaceRepository _placeRepository;
    public HomeController(ILogger<HomeController> logger, IBusRepository busRepository,
        IDriverRepository driverRepository,IRouteRepository routeRepository, IPlaceRepository placeRepository)
    {
        _logger = logger;
        _busRepository = busRepository;
        _driverRepository = driverRepository;
        _routeRepository = routeRepository;
        _placeRepository = placeRepository;
    }

    [Authorize]
    public async Task<ViewResult> Index()
    {
        ViewBag.Buses = await _busRepository.ToListAsync();

        ViewBag.Drivers = await _driverRepository.ToListAsync();
        ViewBag.Routes = await _routeRepository.ToListAsync();
        ViewBag.Places = await _placeRepository.ToListAsync();

        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}