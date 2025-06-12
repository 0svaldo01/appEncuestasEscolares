namespace appEncuestasEscolares.Areas.Encuestador.Models.ViewModels
{
    public class CrearEncuestasViewModel
    {
        public string Titulo { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public string TextoPregunta { get; set; } = "";
    }

}
