using System;
using System.Collections.Generic;

namespace appEncuestasEscolares.Models;

public partial class Rolesusuario
{
    public int IdRol { get; set; }

    public string NombreRol { get; set; } = null!;

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
