using System.ComponentModel.DataAnnotations;

namespace MultiTenantService.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; } 
        public Guid UsuarioId { get; set; }
        public DateTimeOffset FechaCreacion { get; set; } = DateTime.UtcNow.ToUniversalTime();
        public Guid? UsuarioActualizacionId { get; set; }
        public DateTimeOffset? FechaActualizacion { get; set; }
        public Guid? UsuarioEliminacionId { get; set; }
        public DateTimeOffset? FechaEliminacion { get; set; } 
        public bool Activo { get; set; } = true;
    }
}
