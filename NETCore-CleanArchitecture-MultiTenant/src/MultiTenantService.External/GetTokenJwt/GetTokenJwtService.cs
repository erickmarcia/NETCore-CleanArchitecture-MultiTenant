using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MultiTenantService.Application.External.GetTokenJwt;

namespace MultiTenantService.External.GetTokenJwt
{
    public class GetTokenJwtService : IGetTokenJwtService
    {
        private readonly IConfiguration _configuration;
        public GetTokenJwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Execute(string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Acceder al secreto de AppSettings
            var appSettingsSecret = _configuration["AppSettings:SecretKey"];

            // Acceder a las configuraciones de JwtTokenConfig
            var keyJwtSecret = _configuration["JwtTokenConfig:SecretKey"];
            var refreshTokenExpiration = _configuration["JwtTokenConfig:RefreshTokenExpiration"];
            var issuer = _configuration["JwtTokenConfig:Issuer"];
            var audience = _configuration["JwtTokenConfig:Audience"];
            var accessTokenExpiration = _configuration["JwtTokenConfig:AccessTokenExpiration"];
            var subject = _configuration["JwtTokenConfig:Subject"];

            if (keyJwtSecret == null)
            {
                // Manejar el caso en que la clave es nula
            }
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyJwtSecret));

          
            //var key = _configuration["SecretKey"] ?? string.Empty;
            //var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer,// _configuration["IssuerJwt"],
                Audience = audience,// _configuration["AudienceJwt"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
