using AutoMapper;
using WebApiPractica1.DTOs;
using WebApiPractica1.Entidades;

namespace WebApiPractica1.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Vuelo, VueloDTO>().ReverseMap();
            CreateMap<VueloCreacionDTO, Vuelo>();

        }
    }
}
