using appEncuestasEscolares.Areas.Encuestador.Models.ViewModels;
using appEncuestasEscolares.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace appEncuestasEscolares.Areas.Encuestador.Controllers
{
    [Area("Encuestador")]
    [Authorize]
    public class HomeController : Controller
    {
        public EndbContext Context { get; }

        public HomeController(EndbContext context)
        {
            Context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListaEncuestas()
        {
            var idClaim = User.FindFirst("Id")?.Value;

            if (int.TryParse(idClaim, out int idUsuario))
            {
                var usuario = Context.Usuarios.FirstOrDefault(u => u.Id == idUsuario);

                if (usuario == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                var encuestasus = Context.Encuestas.OrderBy(x => x.Titulo).Where(x => x.CreadoPorId == usuario.Id && x.Aplicada == false && x.Aplicada == false).Include(x => x.CreadoPor);
                return View(encuestasus);

            }

            return RedirectToAction("Login", "Login");
        }
        [HttpGet]
        public IActionResult AgregarEncuesta()
        {
            var encues = new CrearEncuestasViewModel();
            return View(encues);
        }
        [HttpPost]
        public IActionResult AgregarEncuesta(CrearEncuestasViewModel vm)
        {
            var existe = Context.Encuestas.Any(x => x.Titulo == vm.Titulo);

            if (existe)
            {
                ModelState.AddModelError("", "La encuesta ya esta registrada");
            }

            if (string.IsNullOrEmpty(vm.Titulo))
            {
                ModelState.AddModelError("", "Agregue un titulo para la encuesta");
            }
            if (string.IsNullOrEmpty(vm.Descripcion))
            {
                ModelState.AddModelError("", "Agregue una descripcion para la encuesta");
            }

            var encuesta = new Encuestas
            {
                Titulo = vm.Titulo,
                Descripcion = vm.Descripcion,
                CreadoPorId = 1, //por mientras
                FechaCreacion = DateTime.Now,
                Eliminada = false,
                Aplicada = false

            };


            //vm.ListaPregCreando.Where(p => !string.IsNullOrWhiteSpace(p.TextoPregunta)))
            //{
            //    encuesta.Preguntas.Add(new Preguntas
            //    {
            //        //TextoPregunta = TextoPregunta,

            //        FechaCreacion = DateTime.Now

            //    });
            //}

            if (ModelState.IsValid)
            {
                Context.Encuestas.Add(encuesta);
                Context.SaveChanges();




                return Redirect("~/Encuestador/Home");
            }


            return View(vm);
        }

        [HttpGet]
        public IActionResult AgregarPreguntas()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AgregarPreguntas(Preguntas p)
        {
            return View();
        }
    }
}
