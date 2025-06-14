﻿using System;
using System.Collections.Generic;

namespace appEncuestasEscolares.Models;

public partial class Preguntas
{
    public int Id { get; set; }

    public int EncuestaId { get; set; }

    public string TextoPregunta { get; set; } = null!;

    public int Orden { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Encuestas Encuesta { get; set; } = null!;

    public virtual ICollection<RespuestasDetalle> RespuestasDetalle { get; set; } = new List<RespuestasDetalle>();
}
