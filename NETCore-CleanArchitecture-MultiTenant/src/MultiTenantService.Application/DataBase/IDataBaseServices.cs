using Microsoft.EntityFrameworkCore;
using MultiTenantService.Domain.Entities.Organizacion;
using MultiTenantService.Domain.Entities.Producto;
using MultiTenantService.Domain.Entities.Usuario;

namespace MultiTenantService.Application.DataBase
{
    public interface IDataBaseService
    {

        public DbSet<OrganizacionEntity> Organizacion { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<ProductoEntity> Producto { get; set; }

        Task<bool> SaveAsync();

    }
}