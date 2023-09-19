using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BusInfo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]

public class DriverController : Controller


{
    private readonly IBusRepository _busRepository;
    private readonly IDriverRepository _driverRepository;
    public DriverController(IDriverRepository driverRepository, IBusRepository busRepository)
    {
        _driverRepository = driverRepository;
        _busRepository = busRepository;
    }
    
    [HttpPost("SignIn")]
    public async Task<Bus> SignIn(string login, string password)
    {
        var driver = await _driverRepository.GetByLogPasswordAsync(login, password);
        var bus = await _busRepository.GetByDriverIdAsync(driver!.Id);
        return bus;
        
    }
    
}