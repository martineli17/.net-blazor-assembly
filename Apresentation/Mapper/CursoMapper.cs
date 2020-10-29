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
            CreateMap<Curso, CursoGetViewModel>()
                .ForMember(dest => dest.Turno, options => options.MapFrom(src => src.Turno.ToString()));
        }
    }
}
