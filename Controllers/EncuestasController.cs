using appEncuestasEscolares.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appEncuestasEscolares.Controllers
{
    public class EncuestasController : Controller
    {
        public DbencuestasContext Context { get; }

        public EncuestasController(DbencuestasContext context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            var data = Context.Encuestas.OrderBy(x => x.NombreEncuesta);
            
            return View(data);
        }
        [HttpGet]
        public IActionResult AgregarEncuestas() 
        {
            var en = new Encuestas();
            return View(en);
        }
        [HttpPost]
        public IActionResult AgregarEncuestas(Encuestas e)
        {
            var existe = Context.Encuestas.Any(x => x.NombreEncuesta == e.NombreEncuesta);
            if (existe)
            {
                ModelState.AddModelError("", "Ya existe");
            }
            if(ModelState.IsValid) 
            {
                Context.Add(e);
                Context.SaveChanges();
                return Redirect("~/Encuestas/Index");
            }
            return View();
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
