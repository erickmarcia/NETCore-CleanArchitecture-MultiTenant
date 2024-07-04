using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantService.Application.Exceptions;
using MultiTenantService.Application.Feactures.Auth;
using MultiTenantService.Common;
using MultiTenantService.Domain.Entities.Producto;
using MultiTenantService.Domain.Models;

namespace MultiTenantService.Application.DataBase.Productos.Commands.CrearProducto
{
    public class CrearProducto : ICrearProducto
    {
        private readonly IProductoDbContext _dataBaseService;
        private readonly IMapper _mapper;
        private readonly IBaseService _baseService;

        public CrearProducto(IProductoDbContext dataBaseService, IMapper mapper,
            IBaseService baseService)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
            _baseService = baseService;
        }

        public async Task<BaseResponseModel> Execute(CrearProductoModel modelo)
        {
            BaseResponseModel mensaje = new BaseResponseModel();
            List<object> errores = new List<object>();

            // Obtener el UsuarioId del usuario autenticado
            // var usuarioId = _baseService.ObtenerIdUsuarioActual();

            var producto = await _dataBaseService.Producto.AsNoTracking().FirstOrDefaultAsync(x => x.Nombre == modelo.Nombre);
            if (producto != null)
            {
                errores.Add(new CustomValidationFailure(Constants.Productos, "Nombre", string.Format(ResponseMessages.AlreadyExists.Message, "Nombre: " + modelo.Nombre), modelo.Nombre));
            }

            if (errores.Any())
            {
                mensaje.Success = false;
                mensaje.CodeId = ResponseMessages.Status400BadRequest.Id;
                mensaje.Message = ResponseMessages.Status400BadRequest.Message;
                mensaje.Data = errores;
                return mensaje;
            }

            var entity = _mapper.Map<ProductoEntity>(modelo);
            
            await _dataBaseService.Producto.AddAsync(entity);

           
            if (await _dataBaseService.SaveAsync())
            {
                mensaje.Success = true;
                mensaje.CodeId = ResponseMessages.Status201Created.Id;
                mensaje.Message = string.Format(Constants.RecursoCreado, Constants.Productos);
                mensaje.Data = true;
            }
            return mensaje;
        }

    }
}
