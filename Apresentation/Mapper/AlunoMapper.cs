using Apresentation.ViewModels.AlunoViewModel;
using AutoMapper;
using Dominio.Entidades;

namespace Apresentation.Mapper
{
    public class AlunoMapper : Profile
    {
        public AlunoMapper()
        {
            CreateMap<AlunoAddViewModel, Aluno>();
            CreateMap<Aluno, AlunoGetViewModel>()
                .ForMember(dest => dest.DataNascimento, 
                options => options.MapFrom(src => src.DataNascimento.ToString("dd/MM/yyyy")));
        }
    }
}
