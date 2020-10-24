using Dominio.Entidades;
using FluentValidation;
using Service.Validators.MessagensValidator;

namespace Service.Validators.ValidatorsEntidades
{
    public class DisciplinaValidator : AbstractValidator<Disciplina>
    {
        public DisciplinaValidator()
        {
            RuleFor(x => x.CargaHoraria).GreaterThanOrEqualTo(0).WithMessage(MensagemValidator.NaoMenorOuIgual("Carga horária"));
            RuleFor(x => x.NotaMinimaAprovacao).GreaterThanOrEqualTo(0).WithMessage(MensagemValidator.NaoMenorOuIgual("Nota mínima para aprovação"));
            RuleFor(x => x.IdCurso).NotEmpty().WithMessage(MensagemValidator.ErroNoProcesso);
            RuleFor(x => x.Nome).NotNull().WithMessage(MensagemValidator.NaoNuloOuVazio("Nome"))
                                .NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Nome"));
        }
    }
}
