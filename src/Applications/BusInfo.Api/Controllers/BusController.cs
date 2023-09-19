using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

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

}