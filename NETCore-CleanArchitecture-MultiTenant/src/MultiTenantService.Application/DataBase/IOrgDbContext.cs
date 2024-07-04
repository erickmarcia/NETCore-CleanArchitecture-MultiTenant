using Microsoft.EntityFrameworkCore;
using MultiTenantService.Domain.Entities.Organizacion;
using MultiTenantService.Domain.Entities.Usuario;

namespace MultiTenantService.Application.DataBase
{
    public interface IOrgDbContext
    {
        public DbSet<OrganizacionEntity> Organizacion { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }

        Task<bool> SaveAsync();

    }
}