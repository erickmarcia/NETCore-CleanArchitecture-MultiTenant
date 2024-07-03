using Newtonsoft.Json;

namespace MultiTenantService.Application.Exceptions
{
    public class ResponseCode
    {
        public int Id { get; set; }
        public string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ErrorList { get; set; }

        public ResponseCode(int id, string message, List<string> errorList = null)
        {
            Id = id;
            Message = message;
            ErrorList = errorList;
        }

        public ResponseCode(ResponseCode appErrorCode, List<string> errorList = null)
        {
            Id = appErrorCode.Id;
            Message = appErrorCode.Message;
            ErrorList = errorList;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
