using appEncuestasEscolares.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext<EndbContext>(options => options.UseMySql("server=localhost;user=root;password=root;database=endb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql")));



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

var app = builder.Build();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.MapAreaControllerRoute(
    name: "areas",
    areaName: "Encuestador",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.UseStaticFiles();
app.Run();
