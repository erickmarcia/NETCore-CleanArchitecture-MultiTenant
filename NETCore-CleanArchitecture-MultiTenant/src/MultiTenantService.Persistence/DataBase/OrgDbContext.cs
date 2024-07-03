﻿using Microsoft.EntityFrameworkCore;
using MultiTenantService.Domain.Entities.Organizacion;
using MultiTenantService.Domain.Entities.Usuario;
using MultiTenantService.Persistence.Configuration.Organizacion;
using MultiTenantService.Persistence.Configuration.Usuarios;
using MultiTenantService.Persistence.Seed;

namespace MultiTenantService.Persistence.DataBase
{
    public class OrgDbContext : DbContext
    {

        public OrgDbContext(DbContextOptions<OrgDbContext> options) : base(options) { }

        public DbSet<OrganizacionEntity> Organizacion { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrganizacionSeed());
            modelBuilder.ApplyConfiguration(new UsuarioSeed());
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new Organizacion(modelBuilder.Entity<OrganizacionEntity>());
            new Usuarios(modelBuilder.Entity<UsuarioEntity>());
        }
    }
}
