using AutoMapper;
using SQ_Evaluacion_API.Dtos;
using SQ_Evaluacion_API.Models;

namespace SQ_Evaluacion_API.Profiles
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreacionFormularioDto, Formulario>();
            CreateMap<Formulario, FormularioDto>();
            CreateMap<Formulario, DetalleFormularioDto>();
            CreateMap<EditarFormularioDto, Formulario>();
        }
    }
}
