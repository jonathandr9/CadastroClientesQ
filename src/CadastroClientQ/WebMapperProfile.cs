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
            CreateMap<Client, ClientFormViewModel>();
        }
    }
}
