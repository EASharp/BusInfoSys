using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

namespace BusInfo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BusController : Controller
{
    private readonly IBusRepository _busRepository;
    
    public BusController(IBusRepository busRepository)
    {
        _busRepository = busRepository;
    }
    [HttpGet("GetEnabled")]
    public async Task<List<Bus>> GetEnabledBuses()
    {
        var list = await _busRepository!.ToListAsync();
        return list;
    }

    [HttpGet("ChangeLatLng")]
    public async Task<Bus> ChangeLatLng(string id, string lat, string lng)
    {
        var bus = await _busRepository.GetByIdAsync(id);
        bus.Latitude = lat;
        bus.Longitude = lng;
        bus.Enabled = true;
       await  _busRepository.SaveChangesAsync();
       return bus;
       
    }

}