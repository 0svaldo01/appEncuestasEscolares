namespace appEncuestasEscolares.Models.DTOs
{
    public class EncuestasDTO
    {
        public class EncuestaDto
        {
            public int Id { get; set; }
            public string Titulo { get; set; } = null!;
            public string? Descripcion { get; set; }
            public int CreadoPorId { get; set; }
            public DateTime? FechaCreacion { get; set; }
            public bool? Eliminada { get; set; }
            public bool? Aplicada { get; set; }

            public string? NombreCreador { get; set; }

            public List<string>? TitulosPreguntas { get; set; }
        }

    }
}
