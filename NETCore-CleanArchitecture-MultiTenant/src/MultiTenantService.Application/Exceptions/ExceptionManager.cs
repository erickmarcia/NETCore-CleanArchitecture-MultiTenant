using MultiTenantService.Application.Feactures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MultiTenantService.Application.Exceptions
{
    public class ExceptionManager : IExceptionFilter 
    {
        public void OnException(ExceptionContext context) 
        {
            context.Result = new ObjectResult(ResponseApiService.Response(ResponseMessages.Status500InternalServerError, null ));
          
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
