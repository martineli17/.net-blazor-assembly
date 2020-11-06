using Crosscuting.Extensions;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using Service.Services.ServicesBase;
using Service.Validators.ValidatorsEntidades;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ContaService : BaseService<Conta>, IContaService
    {
        public ContaService(IContaRepositorio repositorio, InjectorServiceBase injector)
            : base(repositorio, injector)
        {
        }

        public async Task<Conta> AddAsync(Conta entidade)
        {
            if (!await ValidarContaDuplicada(entidade))
                return entidade;
            await base.AddAsync(entidade, new ContaValidator());
            return entidade;
        }

        public async Task<Conta> UpdateAsync(Conta entidade)
        {
            if (!await ValidarContaDuplicada(entidade, true))
                return entidade;
            await base.UpdateAsync(entidade, new ContaValidator());
            return entidade;
        }

        #region Metodos privados
        private async Task<bool> ValidarContaDuplicada(Conta entidade, bool update = false)
        {
            if (entidade == null ||
                (await Repositorio.GetAsync(x => (!update || x.Id != entidade.Id)
                && ((x.NumeroConta == entidade.NumeroConta)))).HasValue())
            {
                Injector.Notificador.Add("Conta já registrada.");
                return false;
            }
            return true;
        }
        #endregion
    }
}
