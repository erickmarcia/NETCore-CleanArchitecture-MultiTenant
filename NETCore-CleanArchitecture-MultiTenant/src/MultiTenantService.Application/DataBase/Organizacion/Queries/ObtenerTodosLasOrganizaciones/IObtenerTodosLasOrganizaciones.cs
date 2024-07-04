using MultiTenantService.Domain.Models;

namespace MultiTenantService.Application.DataBase.Organizacion.Queries.ObtenerTodosLasOrganizaciones
{
    public interface IObtenerTodosLasOrganizaciones
    {
        Task<BaseResponseModel> Execute();
    }
}
