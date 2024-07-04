using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantService.Application.DataBase.Organizacion.Queries.ObtenerOrganizacionIdPorSlug;
using MultiTenantService.Application.Exceptions;
using MultiTenantService.Common;
using MultiTenantService.Domain.Models;

namespace MultiTenantService.Application.DataBase.Productos.Queries.ObtenerProductosPorSlug
{
    public class ObtenerProductosPorSlug : IObtenerProductosPorSlug
    {
        private readonly IProductoDbContext _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IObtenerOrganizacionIdPorSlug _organizationService;

        public ObtenerProductosPorSlug(IProductoDbContext dataBaseService, IMapper mapper,
            IObtenerOrganizacionIdPorSlug organizationService)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _organizationService = organizationService;
        }

        public async Task<BaseResponseModel> Execute(string slugTenant)
        {
            BaseResponseModel responseModel = new BaseResponseModel();
            List<object> errores = new List<object>();

            var organizationId = await _organizationService.ObtenerOrganizacionIdPorSlugAsync(slugTenant);

            if (organizationId == null)
            {
                errores.Add(new CustomValidationFailure(Constants.Productos, "slug", string.Format(ResponseMessages.NoDataFound.Message, "TenantSlug: " + slugTenant), slugTenant));

            }

            var entidad = await _dataBaseService.Producto.AsNoTracking().FirstOrDefaultAsync(x => x.OrganizacionId == organizationId);
            if (entidad == null)
            {
                errores.Add(new CustomValidationFailure(Constants.Productos, "organizationId",
                 string.Format(ResponseMessages.NoDataFoundText.Message, "Producto", "organizationId: " + slugTenant), slugTenant));
            }

            if (errores.Any())
            {
                responseModel.Success = false;
                responseModel.CodeId = ResponseMessages.Status400BadRequest.Id;
                responseModel.Message = ResponseMessages.Status400BadRequest.Message;
                responseModel.Data = errores;
                return responseModel;
            }

            responseModel.Success = true;
            responseModel.CodeId = ResponseMessages.Status200OK.Id;
            responseModel.Message = Constants.Productos;
            responseModel.Data = _mapper.Map<ObtenerProductosPorSlugModel>(entidad);
            return responseModel;

        }
    }
}
