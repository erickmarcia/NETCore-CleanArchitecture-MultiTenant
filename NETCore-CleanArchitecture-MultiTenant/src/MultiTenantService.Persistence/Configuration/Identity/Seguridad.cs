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
            }
        }

        public class CustomIdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
        {
            public void Configure(EntityTypeBuilder<IdentityRole> modelBuilder)
            {
                modelBuilder.ToTable("Roles", "Seguridad");
            }
        }

        public class CustomIdentityUserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> modelBuilder)
            {
                modelBuilder.ToTable("UserLogins", "Seguridad");
             }
        }

        public class CustomIdentityUserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> modelBuilder)
            {
                modelBuilder.ToTable("UserClaims", "Seguridad");
             }
        }

        public class CustomIdentityUserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserToken<string>> modelBuilder)
            {
                modelBuilder.ToTable("UserTokens", "Seguridad");
            }
        }

        public class CustomIdentityRoleClaimsConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> modelBuilder)
            {
                modelBuilder.ToTable("RoleClaims", "Seguridad");
            }
        }

        public class CustomIdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserRole<string>> modelBuilder)
            {
                modelBuilder.ToTable("UserRoles", "Seguridad");
             }
        }

    }
}
