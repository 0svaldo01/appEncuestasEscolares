using appEncuestasEscolares.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appEncuestasEscolares.Controllers
{
    public class HomeController : Controller
    {
        public EndbContext Context { get; }

        public HomeController(EndbContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            var encuestas = Context.Encuestas.OrderBy(x => x.Titulo).Include(x => x.CreadoPor);
            return View(encuestas);
        }
        public IActionResult ContestarEncuesta(int id)
        {
            var encuesta = Context.Encuestas.Any(x=>x.Id == id);
           
            return View(encuesta);
        }
    }
}
