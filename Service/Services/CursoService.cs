using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using Service.Services.ServicesBase;
using Service.Validators.ValidatorsEntidades;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CursoService : BaseService<Curso>, ICursoService
    {
        public CursoService(ICursoRepositorio repositorio, InjectorServiceBase injector) : base(repositorio, injector)
        {
        }

        public async Task<Curso> AddAsync(Curso entidade)
        {
            await base.AddAsync(entidade, new CursoValidator());
            return entidade;
        }

        public async Task<Curso> UpdateAsync(Curso entidade)
        {
            await base.UpdateAsync(entidade, new CursoValidator());
            return entidade;
        }

    }
}
