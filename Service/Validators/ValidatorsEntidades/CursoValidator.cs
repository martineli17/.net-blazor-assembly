using Dominio.Entidades;
using FluentValidation;
using Service.Validators.MessagensValidator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Service.Validators.ValidatorsEntidades
{
    public class CursoValidator :AbstractValidator<Curso>
    {
        public CursoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(MensagemValidator.ErroNoProcesso);
            RuleFor(x => x.Nome).NotNull().MaximumLength(60).WithMessage(MensagemValidator.NaoNuloOuVazio("Nome"));
            RuleFor(x => x.Turno).NotEmpty().IsInEnum().WithMessage(MensagemValidator.IsEnum("Turno"));
        }
    }
}
