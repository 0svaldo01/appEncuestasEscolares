using appEncuestasEscolares.Models.DTOs;

namespace appEncuestasEscolares.Models.ViewModels
{
    public class EncuestasViewModel
    {
        public EncuestasDTO Encuesta { get; set; } = null!;
        public List<string>? Errores { get; set; }

    }
}
