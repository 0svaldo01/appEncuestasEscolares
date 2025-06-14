using appEncuestasEscolares.Areas.Encuestador.Models.DTOs;

namespace appEncuestasEscolares.Areas.Encuestador.Models.ViewModels
{
    public class IndexUsuariosViewModel
    {
        public IEnumerable<UsuarioDTO>? Usuarios { get; set; }
    }
}
