namespace appEncuestasEscolares.Models.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RolId { get; set; }
        public string Rol { get; set; } = null!;
        public DateTime? FechaCreacion { get; set; }
        public bool? Activo { get; set; }
    }
}
