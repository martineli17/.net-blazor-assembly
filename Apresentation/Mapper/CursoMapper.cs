using Apresentation.ViewModels.CursoViewModel;
using AutoMapper;
using Dominio.Entidades;

namespace Apresentation.Mapper
{
    public class CursoMapper : Profile
    {
        public CursoMapper()
        {
            CreateMap<CursoAddViewModel, Curso>();
            CreateMap<CursoGetViewModel, Curso>();
            CreateMap<Curso, CursoGetViewModel>()
                .ForMember(dest => dest.NameTurno, options => options.MapFrom(src => src.Turno.ToString()));
        }
    }
}
