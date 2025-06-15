using appEncuestasEscolares.Models;

using appEncuestasEscolares.Models.DTOs;
using appEncuestasEscolares.Models.ViewModels;
using appEncuestasEscolares.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;

namespace appEncuestasEscolares.Areas.Encuestador.Controllers
{
    [Area("Encuestador")]
    public class HomeController : Controller
    {

        EncuestasService encuestasService = new();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListaEncuestas()
        {
            //var idClaim = User.FindFirst("Id")?.Value;

            //if (int.TryParse(idClaim, out int idUsuario))
            //{
            //    var usuario = Context.Usuarios.FirstOrDefault(u => u.Id == idUsuario);

            //    if (usuario == null)
            //    {
            //        return RedirectToAction("Login", "Login");
            //    }
            //    var encuestasus = Context.Encuestas.OrderBy(x => x.Titulo).Where(x => x.CreadoPorId == usuario.Id && x.Aplicada == false && x.Aplicada == false).Include(x => x.CreadoPor);
            //    return View(encuestasus);

            //}

            //return RedirectToAction("Login", "Login");
            return View();
        }


        [HttpGet]
        public IActionResult AgregarEncuesta()
        {
            EncuestasViewModel vm = new();
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> AgregarEncuesta(EncuestasViewModel vm)
        {
           
            var encuestacreada = await encuestasService.Create(vm.Encuesta);

             return View(vm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AgregarPreguntas(PreguntasViewModel vm)
        {
            var preguntaccreada = await 
        }
        [HttpPost]
        public IActionResult AgregarPreguntas(PreguntasViewModel vm)
        {
            int orden = 1;

            foreach (var texto in vm.Preguntas)
            {
                
                    var pregunta = new Preguntas
                    {
                        EncuestaId = vm.IdEncuesta,
                        TextoPregunta = texto,
                        Orden = orden++,
                        FechaCreacion = DateTime.Now
                    };

                   
               
            }          
            return View(vm);
        }
      
    }
}
