using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenantService.Domain.Entities.Usuario;

namespace MultiTenantService.Persistence.Configuration.Usuarios
{
    public class Usuarios
	{
		public Usuarios(EntityTypeBuilder<UsuarioEntity> entityBuilder)
		{
			entityBuilder.ToTable("Usuarios", "Usuarios");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.UserName).HasMaxLength(120).IsRequired();
            entityBuilder.Property(x => x.Password).HasMaxLength(120).IsRequired();
        }

    }
}

