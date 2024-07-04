using Microsoft.EntityFrameworkCore;
using MultiTenantService.Domain.Entities.Producto;

namespace MultiTenantService.Application.DataBase
{
    public interface IProductoDbContext
    {
        public DbSet<ProductoEntity> Producto { get; set; }

        Task<bool> SaveAsync();

    }
}