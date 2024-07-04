using Microsoft.AspNetCore.Mvc;
using MultiTenantService.Application.DataBase.Productos.Commands.CrearProducto;
using MultiTenantService.Application.DataBase.Productos.Queries.ObtenerProductosPorSlug;
using MultiTenantService.Application.Exceptions;


namespace MultiTenantService.Api.Controllers
{
    [Route("{tenantSlug}/producto")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class ProductoController : Controller
    {     
        [HttpGet("")]
        public async Task<IActionResult> ObtenerProductos(
        [FromServices] IObtenerProductosPorSlug obtenerProductoPorTenantSlug)
        {
            var slugTenant = HttpContext.Items["TenantSlug"]?.ToString();

            var respuesta = await obtenerProductoPorTenantSlug.Execute(slugTenant);

            if (respuesta.Success)
            {
                return StatusCode(StatusCodes.Status200OK, respuesta);
            }
            else
            {
                return StatusCode(respuesta.CodeId, respuesta);
            }
        }

        // POST api/values
        [HttpPost()]
        public async Task<IActionResult> Crear(
         [FromBody] CrearProductoModel modelo,
         [FromServices] ICrearProducto crear
         )
        {
            var slugTenant = HttpContext.Items["TenantSlug"]?.ToString();
            var data = await crear.Execute(modelo, slugTenant);
            if (data.Success)
            {
                return StatusCode(StatusCodes.Status201Created, data);
            }
            else
            {
                return StatusCode(data.CodeId, data);
            }

        }

    }
}

