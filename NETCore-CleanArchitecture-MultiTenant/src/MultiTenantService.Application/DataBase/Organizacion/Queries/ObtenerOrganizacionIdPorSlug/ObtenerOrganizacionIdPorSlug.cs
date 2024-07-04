using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace MultiTenantService.Application.DataBase.Organizacion.Queries.ObtenerOrganizacionIdPorSlug
{
    public class ObtenerOrganizacionIdPorSlug : IObtenerOrganizacionIdPorSlug
    {
        private readonly IOrgDbContext _dataBaseService;
        private readonly IMapper _mapper;

        public ObtenerOrganizacionIdPorSlug(IOrgDbContext dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<int> ObtenerOrganizacionIdPorSlugAsync(string slugTenant)
        {
            var organization = await _dataBaseService.Organizacion
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync(o => o.Nombre == slugTenant);
            return organization.Id;
        }
    }
}
