using AutoMapper;
using MultiTenantService.Application.DataBase.Organizacion.Commands.CrearOrganizacion;
using MultiTenantService.Application.DataBase.Organizacion.Queries.ObtenerOrganizacionIdPorSlug;
using MultiTenantService.Application.DataBase.Organizacion.Queries.ObtenerTodosLasOrganizaciones;
using MultiTenantService.Application.DataBase.Productos.Commands.CrearProducto;
using MultiTenantService.Application.DataBase.Productos.Queries.ObtenerProductosPorSlug;
using MultiTenantService.Domain.Entities.Organizacion;
using MultiTenantService.Domain.Entities.Producto;

namespace MultiTenantService.Application.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile() 
        {
            #region Organizacion

            CreateMap<OrganizacionEntity, CrearOrganizacionModel>().ReverseMap();
            //CreateMap<OrganizacionEntity, ActualizarOrganizacionModel>().ReverseMap();
            CreateMap<OrganizacionEntity, ObtenerTodosLasOrganizacionesModel>().ReverseMap();
            CreateMap<OrganizacionEntity, ObtenerOrganizacionIdPorSlug>().ReverseMap();

            #endregion

            #region Productos

            CreateMap<ProductoEntity, CrearProductoModel>().ReverseMap();
            CreateMap<ProductoEntity, ObtenerProductosPorSlugModel>().ReverseMap();
            #endregion
        }
    }
}
