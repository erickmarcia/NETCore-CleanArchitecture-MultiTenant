using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantService.Application.Exceptions;
using MultiTenantService.Application.Feactures.Auth;
using MultiTenantService.Common;
using MultiTenantService.Domain.Entities.Organizacion;
using MultiTenantService.Domain.Models;

namespace MultiTenantService.Application.DataBase.Organizacion.Commands.CrearOrganizacion
{
    public class CrearOrganizacion : ICrearOrganizacion
    {
        private readonly IDataBaseService _dataBaseService;
        //private readonly IOrgDbContext _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IBaseService _baseService;

        public CrearOrganizacion(IDataBaseService dataBaseService, IMapper mapper,
            IBaseService baseService)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _baseService = baseService;
        }

        public async Task<BaseResponseModel> Execute(CrearOrganizacionModel modelo)
        {
            BaseResponseModel mensaje = new BaseResponseModel();
            List<object> errores = new List<object>();

            // Obtener el UsuarioId del usuario autenticado
            var usuarioId = _baseService.ObtenerIdUsuarioActual();

            var organizacion = await _dataBaseService.Organizacion.AsNoTracking().FirstOrDefaultAsync(x => x.Nombre == modelo.Nombre);
            if (organizacion != null)
            {
                errores.Add(new CustomValidationFailure(Constants.Organizacion, "Nombre", string.Format(ResponseMessages.AlreadyExists.Message, "Nombre: " + modelo.Nombre), modelo.Nombre));
            }

            if (errores.Any())
            {
                mensaje.Success = false;
                mensaje.CodeId = ResponseMessages.Status400BadRequest.Id;
                mensaje.Message = ResponseMessages.Status400BadRequest.Message;
                mensaje.Data = errores;
                return mensaje;
            }

            var entity = _mapper.Map<OrganizacionEntity>(modelo);
            entity.UsuarioId = usuarioId;
            entity.FechaCreacion = DateTime.UtcNow.ToUniversalTime();

            await _dataBaseService.Organizacion.AddAsync(entity);

            if (await _dataBaseService.SaveAsync())
            {
                mensaje.Success = true;
                mensaje.CodeId = ResponseMessages.Status201Created.Id;
                mensaje.Message = string.Format(Constants.RecursoCreado, Constants.Organizacion);
                mensaje.Data = true;
            }
            return mensaje;
        }

    }
}
