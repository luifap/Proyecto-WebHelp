
using AutoMapper;
using WebHelp.DTOs;
using WebHelp.Model;
using System.Globalization;

namespace WebHelp.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            #region Area
            CreateMap<Area, AreaDTO>().ReverseMap();
            #endregion

            #region Subarea
            CreateMap<Subarea, SubareaDTO>().ReverseMap();
            #endregion

            #region Empleado
            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(destino =>
                destino.NombreArea,
                opt => opt.MapFrom(origen => origen.IdAreaNavigation.Nombre)
                )
                .ForMember(destino =>
                destino.NombreSubarea,
                opt => opt.MapFrom(origen => origen.IdSubareaNavigation.Nombre)
                )
                .ForMember(destino =>
                destino.FechaContrato,
                opt => opt.MapFrom(origen => origen.FechaContrato.Value.ToString("dd/MM/yyyy"))
             );

            CreateMap<EmpleadoDTO, Empleado>()
                .ForMember(destino =>
                destino.IdSubareaNavigation,
                opt => opt.Ignore()
               )
                .ForMember(destino =>
                destino.IdAreaNavigation,
                opt => opt.Ignore()
               )
                .ForMember(destino =>
                destino.FechaContrato,
                opt => opt.MapFrom(origen => DateTime.ParseExact(origen.FechaContrato, "dd/MM/yyyy", CultureInfo.InvariantCulture))
               );
            #endregion
        }
    }
}
