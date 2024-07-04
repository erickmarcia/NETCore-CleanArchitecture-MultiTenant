using Microsoft.AspNetCore.Http;

namespace MultiTenantService.Application.External.Services
{
    public class TenantService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetTenantSlug()
        {
            return _httpContextAccessor.HttpContext.Items["TenantSlug"]?.ToString();
        }
    }
}
