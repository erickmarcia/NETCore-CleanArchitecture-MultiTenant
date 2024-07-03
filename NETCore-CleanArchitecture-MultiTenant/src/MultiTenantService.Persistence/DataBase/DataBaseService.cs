using Microsoft.EntityFrameworkCore;
using MultiTenantService.Application.DataBase;
using MultiTenantService.Domain.Entities.Organizacion;
using MultiTenantService.Domain.Entities.Producto;
using MultiTenantService.Domain.Entities.Usuario;
using MultiTenantService.Persistence.Configuration.Organizacion;
using MultiTenantService.Persistence.Configuration.Productos;
using MultiTenantService.Persistence.Configuration.Usuarios;
using MultiTenantService.Persistence.Seed;

namespace MultiTenantService.Persistence.DataBase
{
    public class DataBaseService //: DbContext, IDataBaseService
    {
        //public DataBaseService(DbContextOptions options): base(options) { }

        //public DbSet<OrganizacionEntity> Organizacion { get; set; }
        //public DbSet<UsuarioEntity> Usuario { get; set; }
        //public DbSet<ProductoEntity> Producto { get; set; }
       
 
        //public async Task<bool> SaveAsync()
        //{
        //    return await SaveChangesAsync() > 0;
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasDefaultSchema("public");
        //    base.OnModelCreating(modelBuilder);
        //    EntityConfiguration(modelBuilder);
        //    modelBuilder.ApplyConfiguration(new OrganizacionSeed());
        //    modelBuilder.ApplyConfiguration(new UsuarioSeed());
        //}

        //private void EntityConfiguration(ModelBuilder modelBuilder)
        //{
        //    new Organizacion(modelBuilder.Entity<OrganizacionEntity>());
        //    new Usuarios(modelBuilder.Entity<UsuarioEntity>());
        //    new Productos(modelBuilder.Entity<ProductoEntity>());
        //}
    }
}
