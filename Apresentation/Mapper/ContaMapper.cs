using Apresentation.ViewModels.ContaViewModel;
using AutoMapper;
using Dominio.Entidades;

namespace Apresentation.Mapper
{
    public class ContaMapper : Profile
    {
        public ContaMapper()
        {
            CreateMap<ContaAddViewModel, Conta>();
            CreateMap<Conta, ContaGetViewModel>();
        }
    }
}
