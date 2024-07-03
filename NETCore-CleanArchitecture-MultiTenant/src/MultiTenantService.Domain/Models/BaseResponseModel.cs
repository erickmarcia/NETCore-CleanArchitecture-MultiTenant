namespace MultiTenantService.Domain.Models
{
    public class BaseResponseModel
    {
        public int CodeId { get; set; }
        public bool Success {  get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
