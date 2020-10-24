using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using Service.Services.ServicesBase;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DisciplinaService : BaseService<Disciplina>, IDisciplinaService
    {
        public DisciplinaService(IDisciplinaRepositorio repositorio, InjectorServiceBase injector) : base(repositorio, injector)
        {

        }

        public async Task<Disciplina> AddAsync(Disciplina entidade)
        {
            //if (Injector.Validator.Executar(validation, entidade))
                //await Repositorio.AddAsync(entidade);
            return entidade;
        }

        public Task<Disciplina> UpdateAsync(Disciplina entidade)
        {
            throw new System.NotImplementedException();
        }
    }
}
