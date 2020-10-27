using Apresentation.ViewModels;
using AutoMapper;
using Dominio.Entidades;

namespace Apresentation.Mapper
{
    public class CursoMapper : Profile
    {
        public CursoMapper()
        {
            CreateMap<CursoAddViewModel, Curso>();
        }
    }
}
