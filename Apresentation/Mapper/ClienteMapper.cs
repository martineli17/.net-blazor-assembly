using Apresentation.ViewModels.ClienteViewModel;
using AutoMapper;
using Dominio.Entidades;

namespace Apresentation.Mapper
{
    public class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<ClienteAddViewModel, Cliente>();
            CreateMap<Cliente, ClienteGetViewModel>();
            CreateMap<ClienteGetViewModel, Cliente>();
        }
    }
}
