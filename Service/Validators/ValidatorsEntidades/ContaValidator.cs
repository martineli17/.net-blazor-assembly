using Dominio.Entidades;
using FluentValidation;
using Service.Validators.MessagensValidator;

namespace Service.Validators.ValidatorsEntidades
{
    public class ContaValidator : AbstractValidator<Conta>
    {
        public ContaValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(MensagemValidator.ErroNoProcesso);
            RuleFor(x => x.NumeroConta).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Número da conta"))
                .NotNull().WithMessage(MensagemValidator.NaoNuloOuVazio("Número da conta"))
                .MaximumLength(50).WithMessage(MensagemValidator.NaoMaior("Número da conta"));
            RuleFor(x => x.IdCliente).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Cliente"));
        }
    }
}
