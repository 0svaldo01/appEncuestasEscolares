using System;
using System.Collections.Generic;

namespace appEncuestasEscolares.Models;

public partial class VDashboardEncuestas
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public string? CreadoPor { get; set; }

    public long TotalRespuestas { get; set; }

    public long EncuestadoresActivos { get; set; }

    public bool? Aplicada { get; set; }

    public bool? Eliminada { get; set; }
}
