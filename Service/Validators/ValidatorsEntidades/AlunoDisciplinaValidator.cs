using Dominio.Entidades;
using FluentValidation;
using Service.Validators.MessagensValidator;

namespace Service.Validators.ValidatorsEntidades
{
    public class AlunoDisciplinaValidator : AbstractValidator<AlunoDisciplina>
    {
        public AlunoDisciplinaValidator()
        {
            RuleFor(x => x.Nota).GreaterThanOrEqualTo(0).WithMessage(MensagemValidator.NaoMenorOuIgual("Nota")).When(x => x.Nota.HasValue);
            RuleFor(x => x.Nota).LessThanOrEqualTo(100).WithMessage(MensagemValidator.NaoMaiorOuIgual("Nota")).When(x => x.Nota.HasValue);
            RuleFor(x => x.IdAluno).NotEmpty().WithMessage(MensagemValidator.ErroNoProcesso);
            RuleFor(x => x.IdDisciplina).NotEmpty().WithMessage(MensagemValidator.ErroNoProcesso);
        }
    }
}
