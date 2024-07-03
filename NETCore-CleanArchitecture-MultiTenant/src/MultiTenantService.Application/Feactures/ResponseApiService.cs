using MultiTenantService.Application.Exceptions;
using MultiTenantService.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace MultiTenantService.Application.Feactures
{
    public static class ResponseApiService
    {
        public static BaseResponseModel Response(ResponseCode appError, object Data = null, params object[] args)
        {
            bool success = false;
            if(appError.Id >= 200 && appError.Id < 300 || (appError.Id>=600 && appError.Id <700))
               success = true;

           var  message = string.Format(appError.Message, args);
            if (appError.Message.IsNullOrEmpty())
            {
                message = string.Join(" ", args);
            }
        
            var result = new BaseResponseModel
            {
                CodeId = appError.Id,
                Success = success,
                Message = message,
                Data = Data
            };

            return result;
        }
    }
}
