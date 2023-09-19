using BusInfo.Infrastructure;
using BusInfo.Web.Mapping;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(options => options.DefaultScheme=CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        
        options.LoginPath = "/Auth/SignIn";
        
    });
    
builder.Services.AddAuthentication().AddIdentityCookies();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructureModule();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();