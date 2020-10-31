using Apresentation.ViewModels.DisciplinaViewModel;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Apresentation.Mapper
{
    public class DisciplinaMapper : Profile
    {
        public DisciplinaMapper()
        {
            CreateMap<DisciplinaAddViewModel, Disciplina>();
            CreateMap<Disciplina, DisciplinaGetViewModel>();
            CreateMap<DisciplinaGetViewModel, Disciplina>()
                .ForMember(dest => dest.IdCurso, options => options.MapFrom(src => src.Curso.Id));
        }
        
    }
}
