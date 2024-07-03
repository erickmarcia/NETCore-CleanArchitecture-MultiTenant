namespace MultiTenantService.Application.Feactures.Auth
{
    public interface IBaseService
    {
        Guid ObtenerIdUsuarioActual();
        string ObtenerNombreUsuarioActual();
    }
}
