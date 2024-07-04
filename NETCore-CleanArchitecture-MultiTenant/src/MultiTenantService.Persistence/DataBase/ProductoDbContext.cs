using Microsoft.EntityFrameworkCore;
using MultiTenantService.Application.DataBase;
using MultiTenantService.Domain.Entities.Producto;
using MultiTenantService.Persistence.Configuration.Productos;

namespace MultiTenantService.Persistence.DataBase
{
    public class ProductoDbContext : DbContext, IProductoDbContext
    {
        public ProductoDbContext(DbContextOptions<ProductoDbContext> options) : base(options) { }

        public DbSet<ProductoEntity> Producto { get; set; }
      
        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new Productos(modelBuilder.Entity<ProductoEntity>());
        }
    }
}

