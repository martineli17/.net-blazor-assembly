using System;

namespace Apresentation.Services.Base
{
    public class ServiceBase
    {
        public readonly InjectorServiceBaseApresentation  Injector;
        public ServiceBase(InjectorServiceBaseApresentation injector)
        {
            Injector = injector;
        }

        protected bool ValidarId(Guid id, string mensagem)
        {
            if (id == Guid.Empty)
            {
                Injector.Notificador.Add(mensagem);
                return false;
            }
            return true;
        }
    }
}
