using appEncuestasEscolares.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext<DbencuestasContext>(options => options.UseMySql("server=localhost;user=root;password=root;database=dbencuestas", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql")));
var app = builder.Build();


app.MapDefaultControllerRoute();
app.UseStaticFiles();
app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
