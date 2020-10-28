using Crosscuting.Extensions;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using Service.Services.ServicesBase;
using Service.Validators.ValidatorsEntidades;
using System;
using System.Linq;
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
            if((await Repositorio.GetAsync(x => x.Nome.ToLower() == entidade.Nome.ToLower())).HasValue())
            {
                Injector.Notificador.Add("Já contém um curso cadastrado com o nome solicitado!");
                return entidade;
            }
            await base.AddAsync(entidade, new CursoValidator());
            await Injector.UnitOfWork.CommitAsync();
            return entidade;
        }

        public async Task<Curso> UpdateAsync(Curso entidade)
        {
            await base.UpdateAsync(entidade, new CursoValidator());
            return entidade;
        }

    }
}
