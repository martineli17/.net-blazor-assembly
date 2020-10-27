using Crosscuting.Notificacao;
using System;
using System.Collections.Generic;

namespace Apresentation.Services.Validator
{
    public class ValidatorService
    {
        private readonly Lazy<INotificador> _notificador;
        public ValidatorService(Lazy<INotificador> notificador)
        {
            _notificador = notificador;
        }
        public bool ValidarDadosFormulario(bool isValid, IEnumerable<string> erros = null)
        {
            return true;
        }

        public bool OperacaoValida()
        {
           return _notificador.Value.ContemMensagens();
        }
    }
}
