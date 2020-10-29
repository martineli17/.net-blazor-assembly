using Dominio.Entidades;
using FluentValidation;
using Service.Validators.MessagensValidator;

namespace Service.Validators.ValidatorsEntidades
{
    public class CursoValidator :AbstractValidator<Curso>
    {
        public CursoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(MensagemValidator.ErroNoProcesso);
            RuleFor(x => x.AreaAtuacao).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Área de atuação"))
                .NotNull().WithMessage(MensagemValidator.NaoNuloOuVazio("Área de atuação"));
            RuleFor(x => x.CargaHoraria).GreaterThan(0).WithMessage(MensagemValidator.NaoMenorOuIgual("Carga horária"));
            RuleFor(x => x.Id).NotEmpty().WithMessage(MensagemValidator.ErroNoProcesso);
            RuleFor(x => x.Nome).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Nome"))
                .NotNull().WithMessage(MensagemValidator.NaoNuloOuVazio("Nome"))
                .MaximumLength(60).WithMessage(MensagemValidator.TamanhoMaximo("Nome"));
            RuleFor(x => x.Turno).NotEmpty().IsInEnum().WithMessage(MensagemValidator.IsEnum("Turno"));
        }
    }
}
