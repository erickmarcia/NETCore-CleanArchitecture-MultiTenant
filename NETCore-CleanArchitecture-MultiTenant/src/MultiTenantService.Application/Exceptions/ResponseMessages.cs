using Microsoft.AspNetCore.Http;

namespace MultiTenantService.Application.Exceptions
{
    public class ResponseMessages
    {

        #region 200
        public static readonly ResponseCode Status200OK = new ResponseCode(StatusCodes.Status200OK, "");
        public static readonly ResponseCode Status201Created = new ResponseCode(StatusCodes.Status201Created, "");
        public static readonly ResponseCode Status204NoContent = new ResponseCode(StatusCodes.Status204NoContent, "Sin contenido");

        #endregion

        #region 400

        public static readonly ResponseCode Status400BadRequest = new ResponseCode(StatusCodes.Status400BadRequest, "Solicitud Incorrecta");
        public static readonly ResponseCode Status404NotFound = new ResponseCode(StatusCodes.Status404NotFound, "No encontrado");
        public static readonly ResponseCode Status422UnprocessableEntity = new ResponseCode(StatusCodes.Status422UnprocessableEntity, "Formulario Incompleto");

        #endregion

        #region 500
        public static readonly ResponseCode Status500InternalServerError = new ResponseCode(StatusCodes.Status500InternalServerError, "Error de Servidor");

        #endregion

        #region Mensajes controlados 600 -699

        public static  ResponseCode NoDataFound = new ResponseCode(600, "Lo sentimos, no se encontró data {0}");
        public static ResponseCode NoDataFoundForeingKey = new ResponseCode(601, "Lo sentimos, No se puede insertar el registro porque la clave externa no existe.");
        public static ResponseCode NoDataFoundId = new ResponseCode(602, "Lo sentimos, no se encontró registros en {0} con Id: {1} ");
        public static ResponseCode NoDataFoundText = new ResponseCode(603, "Lo sentimos, no se encontró información en {0} para: {1} ");
        public static ResponseCode AlreadyExists = new ResponseCode(604, "Lo sentimos, {0} ya existe.");
        public static ResponseCode InvalidUserIdentifier = new ResponseCode(605, "Identificador de usuario inválido.");


        #endregion

        #region errores controlados 700 -799

        public static  ResponseCode EndPointDisable = new ResponseCode(700, "Recurso desabilitado.");

        

        #endregion
    }
}
