using appEncuestasEscolares.Models;
using Microsoft.AspNetCore.Mvc;

namespace appEncuestasEscolares.Controllers
{
    public class AccountControllers : Controller
    {
        public DbencuestasContext Context { get; }

        public IActionResult Login()
        {
            return View();
        }
        public AccountControllers(DbencuestasContext context)
        {
            Context = context;
        }
    }
}
