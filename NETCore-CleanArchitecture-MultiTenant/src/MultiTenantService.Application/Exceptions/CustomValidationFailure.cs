namespace MultiTenantService.Application.Exceptions
{
    public class CustomValidationFailure
    {
        public CustomValidationFailure(string tabla, string campo, string errorMessage, object valor)
        {
            this.Tabla = tabla;
            this.Campo = campo;
            this.ErrorMessage = errorMessage;
            this.Valor = valor;
        }

        public string Tabla { get; set; }
        public string Campo { get; set; }
        public string ErrorMessage { get; set; }
        public object Valor { get; set; }
    }
}
