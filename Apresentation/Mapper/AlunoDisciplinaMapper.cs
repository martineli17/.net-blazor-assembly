using Apresentation.ViewModels.AlunoDisciplinaViewModel;
using AutoMapper;
using Dominio.Entidades;

namespace Apresentation.Mapper
{
    public class AlunoDisciplinaMapper : Profile
    {
        public AlunoDisciplinaMapper()
        {
            CreateMap<AlunoDisciplinaAddViewModel, AlunoDisciplina>();
            CreateMap<AlunoDisciplinaGetViewModel, AlunoDisciplina>()
                .BeforeMap((src, dest) => src.Disciplina = null)
                .BeforeMap((src, dest) => src.Aluno = null);
            CreateMap<AlunoDisciplina, AlunoDisciplinaGetViewModel>()
                .AfterMap((src, dest) => dest.Situacao = src.Disciplina.StatusFinalAprovacao(src.Nota.GetValueOrDefault()));
        }
    }
}
