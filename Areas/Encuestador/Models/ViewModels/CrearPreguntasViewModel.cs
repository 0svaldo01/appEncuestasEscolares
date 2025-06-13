using appEncuestasEscolares.Models;

namespace appEncuestasEscolares.Areas.Encuestador.Models.ViewModels
{
    public class CrearPreguntasViewModel
    {
        public int EncuestaId { get; set; }

        public List<string> Preguntas { get; set; } = new();
        
    }   
}
