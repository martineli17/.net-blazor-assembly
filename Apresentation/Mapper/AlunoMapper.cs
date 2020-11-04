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
                .BeforeMap((src, dest) => src.AlunoDisciplina = null)
                .BeforeMap((src, dest) => src.Curso = null);
        }
    }
}
