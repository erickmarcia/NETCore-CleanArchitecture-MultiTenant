using MultiTenantService.Application.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MultiTenantService.Application.Feactures.Auth
{
    public class BaseService : IBaseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServicioAutenticacion _servicioAutenticacion;

        public BaseService(IHttpContextAccessor httpContextAccessor, IServicioAutenticacion servicioAutenticacion)
        {
            _httpContextAccessor = httpContextAccessor;
            _servicioAutenticacion = servicioAutenticacion;
        }

        public Guid ObtenerIdUsuarioActual()
        {   
            var usuario = _httpContextAccessor.HttpContext.User;
            var usuarioIdString = _servicioAutenticacion.ObtenerNameIdentifier(usuario);

            if (!Guid.TryParse(usuarioIdString, out var usuarioId))
            {
                throw new Exception(ResponseMessages.InvalidUserIdentifier.Message);
            }

            return usuarioId;
        }

        public string ObtenerNombreUsuarioActual()
        {
            var usuario = _httpContextAccessor.HttpContext.User;
            return _servicioAutenticacion.ObtenerNombre(usuario);
        }
    }
}
