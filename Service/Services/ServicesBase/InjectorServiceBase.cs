using Service.Validators.ValidadorBase;

namespace Service.Services.ServicesBase
{
    public class InjectorServiceBase
    {
        public readonly IValidacaoFluent Validator;
        public InjectorServiceBase(IValidacaoFluent validator)
        {
            Validator = validator;
        }
    }
}
