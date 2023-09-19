using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BusInfo.Web.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult SignIn(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(string userName, string password, string returnUrl=null)
    {
        if (userName == "Admin" && password == "admin")
        {
            var claims = new List<Claim>()
            {
                new("User", userName),
                new Claim ("Role", "Admin")

            };
            await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "User", "Role")));
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return   Redirect("/Home");
        }

        return View();
    }

    public async Task<IActionResult> SignOutAsync()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("SignIn");
    }

}