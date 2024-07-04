using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MultiTenantService.Application.External.GetTokenJwt;
using MultiTenantService.External.GetTokenJwt;

namespace MultiTenantService.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection
            services, IConfiguration configuration)
        {
            services.AddSingleton<IGetTokenJwtService, GetTokenJwtService>();

            // Leer los valores desde el archivo de configuración
            string authority = configuration["JwtTokenConfig:Authority"];
            string issuer = configuration["JwtTokenConfig:Issuer"]; //configuration["IssuerJwt"]
            string audience = configuration["JwtTokenConfig:Audience"];//configuration["AudienceJwt"]
            string secretKey = configuration["JwtTokenConfig:SecretKey"];


            services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(options =>
                    {
                        options.Authority = authority;
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                           ValidIssuer = issuer,
                           ValidAudience = audience
                        };
                        options.Events = new JwtBearerEvents
                        {
                            OnMessageReceived = context =>
                            {
                                return Task.CompletedTask;
                            }
                        };
                    });

          
            return services;
        }
    }
}
