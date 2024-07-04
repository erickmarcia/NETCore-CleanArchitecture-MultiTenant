using MultiTenantService.Domain.Models;

namespace MultiTenantService.Application.DataBase.Organizacion.Commands.CrearOrganizacion
{
    public interface ICrearOrganizacion
    {
        Task<BaseResponseModel> Execute(CrearOrganizacionModel model);
    }
}
