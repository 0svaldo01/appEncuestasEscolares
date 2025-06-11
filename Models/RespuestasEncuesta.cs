using System;
using System.Collections.Generic;

namespace appEncuestasEscolares.Models;

public partial class RespuestasEncuesta
{
    public int Id { get; set; }

    public int EncuestaId { get; set; }

    public string NumeroControl { get; set; } = null!;

    public string NombreEstudiante { get; set; } = null!;

    public int AplicadaPorId { get; set; }

    public DateTime? FechaRespuesta { get; set; }

    public virtual Usuarios AplicadaPor { get; set; } = null!;

    public virtual Encuestas Encuesta { get; set; } = null!;

    public virtual ICollection<RespuestasDetalle> RespuestasDetalle { get; set; } = new List<RespuestasDetalle>();
}
