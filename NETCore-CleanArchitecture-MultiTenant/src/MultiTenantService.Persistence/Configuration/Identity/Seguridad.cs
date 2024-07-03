using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MultiTenantService.Persistence.Configuration.Identity
{

    public class Seguridad
    {
        public class CustomIdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
        {
            public void Configure(EntityTypeBuilder<IdentityUser> modelBuilder)
            {
                modelBuilder.ToTable("Users", "Seguridad");
               // modelBuilder.Property.Entity<ApplicationUser>()
               //.Property(u => u.DaysToExpire)
               //.IsRequired(false);
               //   builder.Property(u => u.Id).HasColumnName("UsuarioId");
            }
        }

        public class CustomIdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
        {
            public void Configure(EntityTypeBuilder<IdentityRole> modelBuilder)
            {
                modelBuilder.ToTable("Roles", "Seguridad");
                // modelBuilder.Property(r => r.Id).HasColumnName("RoleId");
            }
        }

        public class CustomIdentityUserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> modelBuilder)
            {
                modelBuilder.ToTable("UserLogins", "Seguridad");
                //  modelBuilder.Property(l => l.UserId).HasColumnName("UsuarioId");
            }
        }

        public class CustomIdentityUserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> modelBuilder)
            {
                modelBuilder.ToTable("UserClaims", "Seguridad");
                //  modelBuilder.Property(c => c.Id).HasColumnName("UserClaimId");
            }
        }

        public class CustomIdentityUserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserToken<string>> modelBuilder)
            {
                modelBuilder.ToTable("UserTokens", "Seguridad");
                //  modelBuilder.Property(t => t.UserId).HasColumnName("UsuarioId");
            }
        }

        public class CustomIdentityRoleClaimsConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> modelBuilder)
            {
                modelBuilder.ToTable("RoleClaims", "Seguridad");
                //  modelBuilder.Property(c => c.Id).HasColumnName("RoleClaimId");
            }
        }

        public class CustomIdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserRole<string>> modelBuilder)
            {
                modelBuilder.ToTable("UserRoles", "Seguridad");
                //  modelBuilder.Property(l => l.UserId).HasColumnName("UsuarioId");
            }
        }

    }
}
