namespace Apresentation.Services.Base
{
    public class ServiceBase
    {
        public readonly InjectorServiceBaseApresentation  Injector;
        public ServiceBase(InjectorServiceBaseApresentation injector)
        {
            Injector = injector;
        }
    }
}
