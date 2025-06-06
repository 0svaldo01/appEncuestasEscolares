using System;
using System.Collections.Generic;

namespace appEncuestasEscolares.Models;

public partial class Preguntas
{
    public int IdPregunta { get; set; }

    public string TextoPregunta { get; set; } = null!;

    public int IdEncuesta { get; set; }

    public virtual Encuestas IdEncuestaNavigation { get; set; } = null!;
}
