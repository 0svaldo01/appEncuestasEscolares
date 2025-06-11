using appEncuestasEscolares.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace appEncuestasEscolares.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(EndbContext context)
        {
            Context = context;
        }

        public EndbContext Context { get; }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string user, string password)
        {
            var usuario = Context.Usuarios.SingleOrDefault(x => x.Email == user && x.PasswordHash == password);
            if (usuario != null)
            {
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Email, usuario.Email));
                claims.Add(new Claim(ClaimTypes.Role, usuario.Rol));
                claims.Add(new Claim("Id", usuario.Id.ToString()));

                //identidad
                var identidad = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(new ClaimsPrincipal(identidad));

                return RedirectToAction("Index", "Home", new {area="Encuestador"});
            }
            else
            {
                ModelState.AddModelError("", "El usuario o contraseña son incorrectos");
                return View();
            }

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccesDenied()
        {
            return View();
        }



    }
}
