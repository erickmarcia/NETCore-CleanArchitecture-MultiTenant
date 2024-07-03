namespace MultiTenantService.Application.External.GetTokenJwt
{
    public interface IGetTokenJwtService
    {
        string Execute(string id);
    }
}
