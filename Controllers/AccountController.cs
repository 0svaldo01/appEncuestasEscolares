using appEncuestasEscolares.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using appEncuestasEscolares.Areas.Encuestador.Services;
using appEncuestasEscolares.Models.ViewModels;

namespace appEncuestasEscolares.Controllers
{
    public class AccountController : Controller
    {
        AuthServices authService = new AuthServices();

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new IndexLoginViewModel();


            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(IndexLoginViewModel vm)
        {
            vm.Errores = new List<string>();

            if (string.IsNullOrEmpty(vm.CorreoElectronico))
            {
                ModelState.AddModelError("", "El correo electronico no puede estar vacio");
            }
            if (string.IsNullOrEmpty(vm.Contrasena))
            {
                ModelState.AddModelError("", "La contraseña no puede estar vacia");
            }

            if (vm.Errores.Count() == 0)
            {
                var user = authService.Login(vm.CorreoElectronico, vm.Contrasena).Result;

                if (user != null)
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new("Id",user.Id.ToString()),
                        new(ClaimTypes.Name, user.Nombre),
                        new(ClaimTypes.Email, user.Email),
                        new(ClaimTypes.Role, user.Rol)
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    HttpContext.SignInAsync(new ClaimsPrincipal(identity), new AuthenticationProperties()
                    {
                        IsPersistent = true
                    });

                    if (user.Rol == "Encuestador")
                    {
                        return RedirectToAction("Index", "Home", new { area = "Encuestador" });
                    }


                }

            }

            vm.Errores.Add("Email o Contraseña incorrectas");

            return View(vm);
        }
    }

}

