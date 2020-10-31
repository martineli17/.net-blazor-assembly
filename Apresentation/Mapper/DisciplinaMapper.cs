using Apresentation.ViewModels.DisciplinaViewModel;
using AutoMapper;
using Dominio.Entidades;

namespace Apresentation.Mapper
{
    public class DisciplinaMapper : Profile
    {
        public DisciplinaMapper()
        {
            CreateMap<DisciplinaAddViewModel, Disciplina>();
            CreateMap<Disciplina, DisciplinaGetViewModel>();
            CreateMap<DisciplinaGetViewModel, Disciplina>().BeforeMap((src, dest) => src.Curso = null);
        }
        
    }
}
