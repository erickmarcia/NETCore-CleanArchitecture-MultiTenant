﻿using AutoMapper;
using MultiTenantService.Application.DataBase.Organizacion.Commands.CrearOrganizacion;
using MultiTenantService.Domain.Entities.Organizacion;

namespace MultiTenantService.Application.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile() 
        {
            #region Organizacion

            CreateMap<OrganizacionEntity, CrearOrganizacionModel>().ReverseMap();
            //CreateMap<OrganizacionEntity, ActualizarOrganizacionModel>().ReverseMap();
            //CreateMap<OrganizacionEntity, ObtenerTodasLasOrganizacionModel>().ReverseMap();
            //CreateMap<OrganizacionEntity, ObtenerOrganizacionPorIdModel>().ReverseMap();

            #endregion

        }
    }
}
