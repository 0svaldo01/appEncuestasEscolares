using System;
using System.Collections.Generic;

namespace appEncuestasEscolares.Models;

public partial class Encuestas
{
    public int IdEncuesta { get; set; }

    public string NombreEncuesta { get; set; } = null!;

    public sbyte Estado { get; set; }

    public virtual ICollection<Preguntas> Preguntas { get; set; } = new List<Preguntas>();
}
