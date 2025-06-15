using appEncuestasEscolares.Models;
using appEncuestasEscolares.Models.ViewModels;
using appEncuestasEscolares.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appEncuestasEscolares.Controllers
{
    public class HomeController : Controller
    {

        UsuarioService usuariosService = new();
        EncuestasService encuestaService = new();

        
        public IActionResult Index()
        {
            var usuarios = usuariosService.Get().Result;
            var encuestas = encuestaService.Get().Result;
            IndexEncuestadosViewModel vm = new() 
            {
                
                Usuarios = usuarios,
                Encuestas = encuestas
                
            };

            return View(vm);
        }
        public IActionResult ContestarEncuesta(int id)
        {
            
           
            return View();
        }
    }
}
