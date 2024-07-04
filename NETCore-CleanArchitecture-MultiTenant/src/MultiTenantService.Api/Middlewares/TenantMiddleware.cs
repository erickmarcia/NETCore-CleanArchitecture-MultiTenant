namespace MultiTenantService.Api.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;
        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value;
            var segments = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (segments.Length > 0)
            {
                var tenantSlug = segments[0];

                context.Items["TenantSlug"] = tenantSlug;
            }

            await _next(context);
        }
    }
}
