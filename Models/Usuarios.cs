using System;
using System.Collections.Generic;

namespace appEncuestasEscolares.Models;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string NumeroControl { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public int RolId { get; set; }

    public virtual Rolesusuario Rol { get; set; } = null!;
}
