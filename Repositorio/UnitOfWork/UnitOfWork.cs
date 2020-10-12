using Crosscuting.Notificacao;
using Dominio.Interfaces.Repositorio;
using Repositorio.Contexto;
using System;
using System.Threading.Tasks;

namespace Repositorio.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private readonly INotificador _notificador;
        public UnitOfWork(Context context, INotificador notificador)
        {
            _context = context;
            _notificador = notificador;
        }
        public async Task<bool> CommitAsync()
        {
            try
            {
                using (var transacao = await _context.Database.BeginTransactionAsync())
                {
                    await _context.SaveChangesAsync();
                    await transacao.CommitAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _notificador.Add("Ocorreu um erro ao processar a operação.", EnumTipoMensagem.Erro);
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
