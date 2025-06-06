using System;
using System.Collections.Generic;

namespace appEncuestasEscolares.Models;

public partial class Encuestas
{
    public int IdEncuesta { get; set; }

    public string Titulo { get; set; } = null!;

    public virtual ICollection<Preguntas> Preguntas { get; set; } = new List<Preguntas>();
}
