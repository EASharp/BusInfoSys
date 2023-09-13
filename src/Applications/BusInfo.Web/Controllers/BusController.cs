using AutoMapper;
using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using BusInfo.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusInfo.Web.Controllers;

public class BusController : Controller

{
    private readonly IMapper _mapper;
    private readonly IBusRepository _busRepository;
    private readonly IDriverRepository _driverRepository;

    public BusController(IMapper mapper, IBusRepository busRepository, IDriverRepository driverRepository)
    {
        _busRepository = busRepository;
        _driverRepository = driverRepository;
        _mapper = mapper;
    }

    [Route("/Bus/View/{busId}")]
    public async Task<ViewResult> Bus(string busId)
    {
        var bus = await _busRepository.GetByIdAsync(busId);
        var driver = await _driverRepository.GetByIdAsync(bus.DriverId);
        var viewModel = _mapper.Map<BusViewModel>(bus);
        viewModel.Driver = driver;
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBus(BusViewModel busViewModel)
    {
        var bus = _mapper.Map<Bus>(busViewModel);
        await _busRepository.UpdateAsync(bus);
        return RedirectToAction("Bus", "Bus", new { busId = bus.Id });
    }

    [Route("/Bus/Delete/{busId}")]
    public async Task<RedirectToActionResult> DeleteBus(string busId)
    {
        await _busRepository.RemoveAsync(busId);
        return RedirectToAction("Index", "Home");
    }
}