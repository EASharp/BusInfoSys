using AutoMapper;
using BusInfo.Core.Classes;
using BusInfo.Core.Interfaces.Repositories;
using BusInfo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Route = BusInfo.Core.Classes.Route;

namespace BusInfo.Web.Controllers;

public class UserController : Controller
{
    private readonly IDriverRepository _userDriverRepository;
    private readonly IBusRepository _busRepository;
    private readonly IMapper _mapper;

    public UserController(IDriverRepository userDriverRepository, IBusRepository busRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userDriverRepository = userDriverRepository;
        _busRepository = busRepository;
    }

    [Route("Driver/View/{userid}")]
    public async Task<ViewResult> Profile(string userid)
    {
        var driver = await _userDriverRepository.GetByIdAsync(userid);

        var viewModel = _mapper.Map<DriverViewModel>(driver);
        if (await _busRepository.IsDriverIdExistAsync(userid))
        {
            var bus = await _busRepository.GetByDriverIdAsync(userid);
            viewModel.Bus = bus;
        }

        return View(viewModel);
    }

    [Route("Driver/Add/")]
    public Task<ViewResult> Profile()
    {
        return Task.FromResult(View(new DriverViewModel { Id = Guid.NewGuid().ToString("N"),IsCreate = true}));
        
    }

    [Route("/Drivers")]
    public async Task<ViewResult> UserList()
    {
        var list =await  _userDriverRepository.ToListAsync();
        return View(list);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProfile(DriverViewModel driverViewModel)
    {
        
        var driver = _mapper.Map<Driver>(driverViewModel);
        if (driverViewModel.IsCreate)
        {
            await _userDriverRepository.AddAsync(driver);
        }
        else
        {
            await _userDriverRepository.UpdateAsync(driver);       
        }
     
        
        return RedirectToAction("Profile", "User", new { userid = driverViewModel.Id });
    }

    [Route("User/Delete/{userid}/")]
    public async Task<IActionResult> Delete(string userid)
    {
        await _userDriverRepository.RemoveAsync(userid);
        return RedirectToAction("UserList", "User");
    }
}