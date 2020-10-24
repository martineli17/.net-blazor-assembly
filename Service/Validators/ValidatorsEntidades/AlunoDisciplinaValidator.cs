using Dominio.Entidades;
using FluentValidation;
using Service.Validators.MessagensValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Validators.ValidatorsEntidades
{
    public class AlunoDisciplinaValidator : AbstractValidator<AlunoDisciplina>
    {
        public AlunoDisciplinaValidator()
        {
            RuleFor(x => x.Nota).GreaterThanOrEqualTo(0).WithMessage(MensagemValidator.NaoMenorOuIgual("Nota"));
            RuleFor(x => x.IdAluno).NotEmpty().WithMessage(MensagemValidator.ErroNoProcesso);
            RuleFor(x => x.IdDisciplina).NotEmpty().WithMessage(MensagemValidator.ErroNoProcesso);
        }
    }
}
