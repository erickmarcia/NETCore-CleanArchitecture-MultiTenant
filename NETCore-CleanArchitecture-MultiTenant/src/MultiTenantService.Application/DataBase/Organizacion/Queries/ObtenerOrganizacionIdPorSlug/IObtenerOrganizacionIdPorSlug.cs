namespace MultiTenantService.Application.DataBase.Organizacion.Queries.ObtenerOrganizacionIdPorSlug
{
    public interface IObtenerOrganizacionIdPorSlug
    {
        Task<int> ObtenerOrganizacionIdPorSlugAsync(string slugTenant);
    }
}
