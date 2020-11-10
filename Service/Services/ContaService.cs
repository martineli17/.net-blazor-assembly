using Crosscuting.Extensions;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using Dominio.ValuesType;
using Service.Services.ServicesBase;
using Service.Validators.ValidatorsEntidades;
using System;
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

        public async Task RealizarOperacao(EnumOperacaoConta operaco, Guid idConta, decimal valor, 
                                           Guid? idContaDestino = null)
        {
            switch (operaco)
            {
                case EnumOperacaoConta.Transferir: 
                    await TranserirAsync(idConta, idContaDestino ?? Guid.Empty, valor); break;
                case EnumOperacaoConta.Depositar:
                    await DepositarAsync(idConta, valor); break;
                case EnumOperacaoConta.Sacar:
                    await SacarAsync(idConta, valor); break;
                default: break;
            }
        }

        #region Metodos privados
        private async Task TranserirAsync(Guid idConta, Guid idContaDestino, decimal valor)
        {
            if (!ValidarValor(valor)) return;
            var entidade = await ValidarConta(idConta);
            var entidadeDestino = await ValidarConta(idContaDestino);
            if (entidade is null || entidadeDestino is null) return;
            if (!entidade.Sacar(valor))
            {
                Injector.Notificador.Add("Saldo insuficiente para transferir o valor desejado!");
                return;
            }
            entidadeDestino.Depositar(valor);
            await Repositorio.UpdateAsync(entidade);
            await Repositorio.UpdateAsync(entidadeDestino);
            await Injector.UnitOfWork.CommitAsync();
        }

        private async Task SacarAsync(Guid idConta, decimal valor)
        {
            if (!ValidarValor(valor)) return;
            var entidade = await ValidarConta(idConta);
            if (entidade is null) return;
            if (!entidade.Sacar(valor))
            {
                Injector.Notificador.Add("Saldo insuficiente para sacar o valor desejado!");
                return;
            }
            await Repositorio.UpdateAsync(entidade);
            await Injector.UnitOfWork.CommitAsync();
        }

        private async Task DepositarAsync(Guid idConta, decimal valor)
        {
            if (!ValidarValor(valor)) return;
            var entidade = await ValidarConta(idConta);
            if (entidade is null) return;
            entidade.Depositar(valor);
            await Repositorio.UpdateAsync(entidade);
            await Injector.UnitOfWork.CommitAsync();
        }


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

        private async Task<Conta> ValidarConta(Guid id)
        {
            if (id == Guid.Empty)
            {
                Injector.Notificador.Add("Conta solicitada não existe.");
                return null;
            }
            var entidade = await Repositorio.GetByIdAsync(id);
            if (entidade is null)
            {
                Injector.Notificador.Add("Conta solicitada não existe.");
                return null;
            }
            return entidade;
        }

        private bool ValidarValor(decimal valor)
        {
            if (valor <= 0)
            {
                Injector.Notificador.Add("Valor inválido. Deve ser maior que R$0,00 .");
                return false;
            }
            return true;
        }
        #endregion
    }
}
