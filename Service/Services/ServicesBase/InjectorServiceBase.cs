using Crosscuting.Notificacao;
using Service.Validators.ValidadorBase;

namespace Service.Services.ServicesBase
{
    public class InjectorServiceBase
    {
        public readonly IValidacaoFluent Validator;
        public readonly INotificador Notificador;
        public InjectorServiceBase(IValidacaoFluent validator, INotificador notificador)
        {
            Validator = validator;
            Notificador = notificador;
        }
    }
}
