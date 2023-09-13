using Microsoft.AspNetCore.Mvc;

namespace BusInfo.Web.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult SignIn()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }
}