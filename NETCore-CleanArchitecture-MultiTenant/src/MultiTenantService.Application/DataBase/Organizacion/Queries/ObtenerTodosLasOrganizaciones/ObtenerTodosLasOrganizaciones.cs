using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantService.Application.Exceptions;
using MultiTenantService.Common;
using MultiTenantService.Domain.Models;

namespace MultiTenantService.Application.DataBase.Organizacion.Queries.ObtenerTodosLasOrganizaciones
{
    public class ObtenerTodosLasOrganizaciones : IObtenerTodosLasOrganizaciones
    {
        private readonly IOrgDbContext _dataBaseService;
        private readonly IMapper _mapper;
        public ObtenerTodosLasOrganizaciones(IOrgDbContext dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> Execute()
        {
            BaseResponseModel responseModel = new BaseResponseModel();
            List<object> errores = new List<object>();

            var entidad = _dataBaseService.Organizacion.Where(x => x.Activo).AsQueryable();
            if (entidad == null)
            {
                errores.Add(new CustomValidationFailure(Constants.Organizacion, "organizationId",
                 string.Format(ResponseMessages.NoDataFoundText.Message, "Organizacion", "organizationId: " ), "Organizacion"));
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
            responseModel.Message = Constants.Organizacion;
            responseModel.Data = _mapper.Map< List<ObtenerTodosLasOrganizacionesModel>>(entidad);
            return responseModel;

        }
    }
}
