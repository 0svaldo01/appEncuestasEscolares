﻿using appEncuestasEscolares.Models.ViewModels;
using appEncuestasEscolares.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace appEncuestasEscolares.Areas.Encuestador.Controllers
{
    [Area("Encuestador")]


    public class UsuarioController : Controller
    {
        UsuarioService usuarioservice = new();

        public IActionResult Index()
        {
            var usuarios = usuarioservice.Get().Result;
            IndexUsuariosViewModel model = new()
            {
                Usuarios = usuarios
            };

            return View(model);
        }
        public IActionResult Agregar()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult Eliminar()
        {
            return View();
        }
    }
}
