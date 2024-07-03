using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenantService.Domain.Entities.Producto;

namespace MultiTenantService.Persistence.Configuration.Productos
{
    public class Productos
	{
		public Productos(EntityTypeBuilder<ProductoEntity> entityBuilder)
		{
            entityBuilder.ToTable("Productos", "Productos");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Nombre).HasMaxLength(120).IsRequired();
            entityBuilder.Property(x => x.Precio).HasPrecision(18, 2);

        }
    }
}

