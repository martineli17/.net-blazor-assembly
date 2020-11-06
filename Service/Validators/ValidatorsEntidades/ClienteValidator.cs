using Crosscuting.Funcoes;
using Dominio.Entidades;
using FluentValidation;
using Service.Validators.MessagensValidator;

namespace Service.Validators.ValidatorsEntidades
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(MensagemValidator.ErroNoProcesso);
            RuleFor(x => x.Nome).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Nome"))
                .NotNull().WithMessage(MensagemValidator.NaoNuloOuVazio("Nome"))
                .MaximumLength(60).WithMessage(MensagemValidator.TamanhoMaximo("Nome"));
            RuleFor(x => x.Cpf).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("CPF"))
                .NotNull().WithMessage(MensagemValidator.NaoNuloOuVazio("CPF"));
            RuleFor(x => x.Cpf).Must(ValidadorCpf.ValidarCpf).WithMessage("CPF informado está inválido.");
            RuleFor(x => x.DataNascimento).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Data de nascimento"));
            RuleFor(x => x.DataNascimento).Must((entity, value) => entity.GetIdade() >= 16).WithMessage("É necessário que o cliente seja maior de 16 anos.");
        }
    }
}
