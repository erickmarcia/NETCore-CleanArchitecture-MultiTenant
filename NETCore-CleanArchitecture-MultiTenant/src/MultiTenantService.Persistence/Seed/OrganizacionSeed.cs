using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenantService.Domain.Entities.Organizacion;

namespace MultiTenantService.Persistence.Seed
{
    public class OrganizacionSeed : IEntityTypeConfiguration<OrganizacionEntity>
    {
        public void Configure(EntityTypeBuilder<OrganizacionEntity> builder)
        {
            int id = 0;
            var listOrganizacion = new List<OrganizacionEntity>
            {
                new OrganizacionEntity
                {
                    Id= ++id,
                    Nombre = "Organizacion1",
                    FechaCreacion=DateTime.Now,
                    Activo=true
                }
            };
            builder.HasData(listOrganizacion);
        }
    }
}
