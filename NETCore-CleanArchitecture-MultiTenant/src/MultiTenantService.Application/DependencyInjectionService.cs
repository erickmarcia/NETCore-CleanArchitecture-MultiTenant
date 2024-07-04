using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantService.Application.Configuration;
using MultiTenantService.Application.DataBase.Organizacion.Commands.CrearOrganizacion;
using MultiTenantService.Application.Feactures.Auth;

namespace MultiTenantService.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            // Registrar IHttpContextAccessor
            services.AddHttpContextAccessor();
            services.AddScoped<IServicioAutenticacion, ServicioAutenticacion>();
            services.AddTransient<IBaseService, BaseService>();
            //registramos servicios
            services.AddSingleton(mapper.CreateMapper());

            #region Organizacion
            services.AddTransient<ICrearOrganizacion, CrearOrganizacion>();
           

            #endregion

            #region Usuarios
         

            #endregion

            #region Productos
          

            #endregion

            #region Validators
           // services.AddScoped<IValidator<CrearOrganizacionModel>, CrearOrganizacionValidator>();
           


            #endregion

         
            return services;
        }
    }
}
