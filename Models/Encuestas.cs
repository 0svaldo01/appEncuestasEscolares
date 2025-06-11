using System;
using System.Collections.Generic;

namespace appEncuestasEscolares.Models;

public partial class Encuestas
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int CreadoPorId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool? Eliminada { get; set; }

    public bool? Aplicada { get; set; }

    public virtual Usuarios CreadoPor { get; set; } = null!;

    public virtual ICollection<Preguntas> Preguntas { get; set; } = new List<Preguntas>();

    public virtual ICollection<RespuestasEncuesta> RespuestasEncuesta { get; set; } = new List<RespuestasEncuesta>();
}
