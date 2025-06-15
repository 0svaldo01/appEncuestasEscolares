using appEncuestasEscolares.Models.DTOs;

namespace appEncuestasEscolares.Models.ViewModels
{
    public class PreguntasViewModel
    {
        public int IdEncuesta { get; set; }
        public IEnumerable<PreguntasDTO> Prguntas { get; set; } = null!;

        public List<string> Errores { get; set; }
    }
}
