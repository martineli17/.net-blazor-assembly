using Crosscuting.Notificacao;
using FluentValidation;
using System.Linq;

namespace Service.Validators
{
    public class ValidacaoFluent
    {
        private readonly INotificador _notificador;
        public ValidacaoFluent(INotificador notificador)
        {
            _notificador = notificador;
        }
        public bool Executar<TValidator, TObject>(TValidator validator, TObject objeto) where TValidator : AbstractValidator<TObject>
        {
            var validacao = validator.Validate(objeto);
            if (!validacao.IsValid)
                _notificador.AddRange(validacao.Errors.Select(x => x.ErrorMessage).ToList(), EnumTipoMensagem.Warning);
            return validacao.IsValid;
        }
    }

    public interface IValidacaoFluent 
    {
        bool Executar<TValidator, TObject>(TValidator validator, TObject objeto) where TValidator : AbstractValidator<TObject>;
    }
}
