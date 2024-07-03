using Microsoft.EntityFrameworkCore;
using MultiTenantService.Domain.Entities.Producto;
using MultiTenantService.Persistence.Configuration.Productos;

namespace MultiTenantService.Persistence.DataBase
{
    public class ProductoDbContext : DbContext
    {
        public ProductoDbContext(DbContextOptions<ProductoDbContext> options) : base(options) { }

        public DbSet<ProductoEntity> Productos { get; set; }

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

