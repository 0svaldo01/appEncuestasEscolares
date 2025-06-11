using System;
using System.Collections.Generic;

namespace appEncuestasEscolares.Models;

public partial class Usuarios
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Encuestas> Encuestas { get; set; } = new List<Encuestas>();

    public virtual ICollection<RespuestasEncuesta> RespuestasEncuesta { get; set; } = new List<RespuestasEncuesta>();
}
