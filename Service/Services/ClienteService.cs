using Crosscuting.Extensions;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using Service.Services.ServicesBase;
using Service.Validators.ValidatorsEntidades;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        public ClienteService(IClienteRepositorio repositorio, InjectorServiceBase injector)
            : base(repositorio, injector)
        {
        }

        public async Task<Cliente> AddAsync(Cliente entidade)
        {
            if (!await ValidarClienteDuplicado(entidade))
                return entidade;
            await base.AddAsync(entidade, new ClienteValidator());
            return entidade;
        }

        public async Task<Cliente> UpdateAsync(Cliente entidade)
        {
            if (!await ValidarClienteDuplicado(entidade, true))
                return entidade;
            await base.UpdateAsync(entidade, new ClienteValidator());
            return entidade;
        }

        #region Metodos privados
        private async Task<bool> ValidarClienteDuplicado(Cliente entidade, bool update = false)
        {
            if (entidade == null ||
                (await Repositorio.GetAsync(x => (!update || x.Id != entidade.Id)
                && ((x.Cpf == entidade.Cpf) ||
                (!update && x.Nome != entidade.Nome && x.Cpf == entidade.Cpf)))).HasValue())
            {
                Injector.Notificador.Add("Cliente já registrado.");
                return false;
            }
            return true;
        }
        #endregion
    }
}
