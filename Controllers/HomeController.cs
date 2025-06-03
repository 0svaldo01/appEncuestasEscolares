using Microsoft.AspNetCore.Mvc;

namespace appEncuestasEscolares.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
