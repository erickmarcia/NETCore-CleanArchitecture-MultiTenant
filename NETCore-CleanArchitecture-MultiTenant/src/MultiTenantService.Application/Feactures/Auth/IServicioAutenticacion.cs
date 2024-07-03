using System.Security.Claims;

namespace MultiTenantService.Application.Feactures.Auth
{
    public interface IServicioAutenticacion
    {
        string ObtenerNameIdentifier(ClaimsPrincipal user);
        string ObtenerNombre(ClaimsPrincipal user);
        IEnumerable<string> ObtenerRoles(ClaimsPrincipal user);
    }
}
