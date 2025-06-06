using System;
using System.Collections.Generic;

namespace appEncuestasEscolares.Models;

public partial class Usuariosencuestado
{
    public int IdUsEncs { get; set; }

    public string NumeroControl { get; set; } = null!;

    public string Nombre { get; set; } = null!;
}
