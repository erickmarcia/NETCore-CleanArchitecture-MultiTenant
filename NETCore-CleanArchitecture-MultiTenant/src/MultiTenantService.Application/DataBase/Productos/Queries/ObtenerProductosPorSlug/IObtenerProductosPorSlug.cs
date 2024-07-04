using MultiTenantService.Domain.Models;

namespace MultiTenantService.Application.DataBase.Productos.Queries.ObtenerProductosPorSlug
{
    public interface IObtenerProductosPorSlug
    {
        Task<BaseResponseModel> Execute(string slugTenant);
    }
}
