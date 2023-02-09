using AutoMapper;
using CadastroClientQ.Domain.Models;
using IBGEServicoDados.ApiAdapter.Models;

namespace IBGEServicoDados.ApiAdapter.Configuration
{
    public class IBGEApiProfileMapper : Profile
    {
        public IBGEApiProfileMapper()
        {
            CreateMap<GetStatesDto, State>()
              .ForMember(o => o.Id, d => d.MapFrom(src => src.id))
              .ForMember(o => o.Acronym, d => d.MapFrom(src => src.sigla))
              .ForMember(o => o.Description, d => d.MapFrom(src => src.nome));

            CreateMap<GetCitiesDto, City>()
              .ForMember(o => o.Id, d => d.MapFrom(src => src.id))
              .ForMember(o => o.Description, d => d.MapFrom(src => src.nome));
        }
    }
}
