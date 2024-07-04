using Microsoft.AspNetCore.Mvc;
using MultiTenantService.Application.DataBase.Organizacion.Commands.CrearOrganizacion;
using MultiTenantService.Application.Exceptions;

namespace MultiTenantService.Api.Controllers
{
    [Route("api/organizacion")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class OrganizacionController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

