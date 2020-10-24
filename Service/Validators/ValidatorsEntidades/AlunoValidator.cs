using Crosscuting.Funcoes;
using Dominio.Entidades;
using FluentValidation;
using Service.Validators.MessagensValidator;

namespace Service.Validators.ValidatorsEntidades
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(MensagemValidator.ErroNoProcesso);
            RuleFor(x => x.Nome).NotNull().WithMessage(MensagemValidator.NaoNuloOuVazio("Nome"))
                .MaximumLength(60).WithMessage(MensagemValidator.TamanhoMaximo("Nome"));
            RuleFor(x => x.Cpf).NotNull().WithMessage(MensagemValidator.NaoNuloOuVazio("CPF"))
                .Must(ValidadorCpf.ValidarCpf).WithMessage("CPF informado está inválido.");
            RuleFor(x => x.IdCurso).NotNull().WithMessage(MensagemValidator.NaoNuloOuVazio("Curso"));
            RuleFor(x => x.DataNascimento).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Data de nascimento"))
                .Must((entity, value) => entity.GetIdade() >= 18).WithMessage("É necessário que o aluno seja maior de 18 anos.");
        }
    }
}
