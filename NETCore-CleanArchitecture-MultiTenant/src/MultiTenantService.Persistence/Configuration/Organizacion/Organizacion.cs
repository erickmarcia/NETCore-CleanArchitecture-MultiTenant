using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenantService.Domain.Entities.Organizacion;

namespace MultiTenantService.Persistence.Configuration.Organizacion
{
    public class Organizacion
	{
		public Organizacion(EntityTypeBuilder<OrganizacionEntity> entityBuilder)
		{
            entityBuilder.ToTable("Organizacion", "Organizacion");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Nombre).HasMaxLength(120).IsRequired();

        }
    }
}

