using MultiTenantService.Domain.Models;

namespace MultiTenantService.Application.DataBase.Productos.Commands.CrearProducto
{
    public interface ICrearProducto
    {
        Task<BaseResponseModel> Execute(CrearProductoModel model);
    }
}
