using appEncuestasEscolares.Areas.Encuestador.Models.DTOs;
using appEncuestasEscolares.Models.DTOs;

namespace appEncuestasEscolares.Models.ViewModels
{
    public class IndexEncuestadosViewModel
    {
        public IEnumerable<UsuarioDTO>? Usuarios { get; set; }
        public IEnumerable<EncuestasDTO>? Encuestas { get; set; }
    }
}
