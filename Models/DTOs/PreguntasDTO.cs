namespace appEncuestasEscolares.Models.DTOs
{
    public class PreguntasDTO
    {
        public int Id { get; set; }

        public int EncuestaId { get; set; }

        public string TextoPregunta { get; set; } = null!;

        public int Orden { get; set; }

        public DateTime? FechaCreacion { get; set; }

    }

}
