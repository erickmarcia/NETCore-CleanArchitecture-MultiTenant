using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenantService.Domain.Entities.Usuario;

namespace MultiTenantService.Persistence.Seed
{
    public class UsuarioSeed : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            int id = 0;
            var listUsuarios = new List<UsuarioEntity>
            {
                new UsuarioEntity
                {   Id = ++id,
                    UserName = "Admin",
                    Password = "Admin.123",
                    OrganizacionId = 1,
                    FechaCreacion=DateTime.Now,
                    Activo = true
                }
            };
            builder.HasData(listUsuarios);
        }
    }
}
