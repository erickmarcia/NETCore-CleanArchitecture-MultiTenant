using MultiTenantService.Domain.Common;
using MultiTenantService.Domain.Entities.Organizacion;

namespace MultiTenantService.Domain.Entities.Usuario
{
    public class UsuarioEntity : BaseEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int OrganizacionId { get; set; }
        public OrganizacionEntity Organizacion { get; set; }
    }
}

