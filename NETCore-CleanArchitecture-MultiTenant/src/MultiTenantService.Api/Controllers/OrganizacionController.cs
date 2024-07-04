using Microsoft.AspNetCore.Mvc;
using MultiTenantService.Application.DataBase.Organizacion.Commands.CrearOrganizacion;
using MultiTenantService.Application.DataBase.Organizacion.Queries.ObtenerTodosLasOrganizaciones;
using MultiTenantService.Application.Exceptions;

namespace MultiTenantService.Api.Controllers
{
    [Route("api/organizacion")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class OrganizacionController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> ObtenerOrganizaciones(
         [FromServices] IObtenerTodosLasOrganizaciones obtenerTodosLasOrganizaciones)
        {       
            var respuesta = await obtenerTodosLasOrganizaciones.Execute();

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
         [FromBody] CrearOrganizacionModel modelo,
         [FromServices] ICrearOrganizacion crear
         )
        {
            var data = await crear.Execute(modelo);
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

