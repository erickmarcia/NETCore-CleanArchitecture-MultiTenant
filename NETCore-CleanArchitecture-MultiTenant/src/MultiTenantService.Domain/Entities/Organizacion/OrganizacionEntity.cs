using MultiTenantService.Domain.Common;
using MultiTenantService.Domain.Entities.Usuario;

namespace MultiTenantService.Domain.Entities.Organizacion
{
    public class OrganizacionEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<UsuarioEntity> Usuario { get; set; }
    }
}

