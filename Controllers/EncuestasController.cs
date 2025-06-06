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
            var data = Context.Encuestas.OrderBy(x => x.Titulo);
            
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
            var existe = Context.Encuestas.Any(x => x.Titulo == e.Titulo);
            if (existe)
            {
                ModelState.AddModelError("", "Ya existe");
            }
            if(ModelState.IsValid) 
            {
                Context.Add(e);
                Context.SaveChanges();
                return Redirect("~/Encuestas/Encuestas");
            }
            return View();
        }

    }
}
