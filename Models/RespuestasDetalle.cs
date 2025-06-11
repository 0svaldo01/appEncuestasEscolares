using System;
using System.Collections.Generic;

namespace appEncuestasEscolares.Models;

public partial class RespuestasDetalle
{
    public int Id { get; set; }

    public int RespuestaEncuestaId { get; set; }

    public int PreguntaId { get; set; }

    public int Calificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Preguntas Pregunta { get; set; } = null!;

    public virtual RespuestasEncuesta RespuestaEncuesta { get; set; } = null!;
}
