using AutoMapper;
using CadastroClientQ.Domain.Models;
using CadastroClientQ.WebApp.Models;

namespace CadastroClientQ.WebApp
{
    public class WebMapperProfile : Profile
    {
        public WebMapperProfile()
        {
            CreateMap<AddClientViewModel, Client>();
            CreateMap<Client, ClientViewModel>()
               .ForMember(o => o.Sex, d => d.MapFrom(src => GetSex(src.Sex)))
               .ForMember(o => o.SexId, d => d.MapFrom(src => src.Sex));
        }

        public string GetSex(int value)
        {
            switch (value)
            {
                case 1:
                    return "Masculino";
                case 2:
                    return "Feminino";
                case 3:
                    return "Não Informado";
                default: return "Não Informado";
                    break;
            }
        }
    }
}
