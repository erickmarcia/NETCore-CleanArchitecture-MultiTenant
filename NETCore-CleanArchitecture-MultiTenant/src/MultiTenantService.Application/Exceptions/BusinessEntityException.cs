namespace MultiTenantService.Application.Exceptions
{

    public class BusinessEntityException : Exception
    {
        public ResponseCode AppError { get; set; }

        public BusinessEntityException()
        {
        }

        public BusinessEntityException(string message)
            : base(message)
        {
        }

        public BusinessEntityException(ResponseCode code)
            : base(code.Message)
        {
            AppError = code;
        }

        public BusinessEntityException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public BusinessEntityException(ResponseCode code, List<string> errorList)
            : base(code.Message)
        {
            code.ErrorList = errorList;
            AppError = code;
        }

        public BusinessEntityException(ResponseCode code, params object[] param)
            : base(code.Message)
        {
            var newMessage = string.Format(code.Message, param);
            AppError = new ResponseCode(code.Id, newMessage);
        }
    }
}
