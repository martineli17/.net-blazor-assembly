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
            CreateMap<Aluno, AlunoGetViewModel>();
            CreateMap<AlunoGetViewModel, Aluno>()
                .ForMember(dest => dest.IdCurso, options => options.MapFrom(src => src.Curso.Id));
        }
    }
}
