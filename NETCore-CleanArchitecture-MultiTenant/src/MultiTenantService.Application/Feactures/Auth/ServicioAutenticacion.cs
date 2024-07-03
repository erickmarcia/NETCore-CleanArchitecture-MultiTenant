using System.Security.Claims;

namespace MultiTenantService.Application.Feactures.Auth
{
    public class ServicioAutenticacion : IServicioAutenticacion
    {
        public string ObtenerNameIdentifier(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public string ObtenerNombre(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public IEnumerable<string> ObtenerRoles(ClaimsPrincipal user)
        {
            return user.FindAll(ClaimTypes.Role).Select(c => c.Value);
        }
    }
}
