using Apresentation.ViewModels.AlunoViewModel;
using Apresentation.ViewModels.DisciplinaViewModel;
using Dominio.ValuesType;
using System;

namespace Apresentation.ViewModels.AlunoDisciplinaViewModel
{
    public class AlunoDisciplinaGetViewModel : AlunoDisciplinaBaseViewModel
    {
        public DisciplinaGetViewModel Disciplina { get; set; }
        public AlunoGetViewModel Aluno { get; set; }
        public EnumStatusFinal Situacao { get; set; }

        public string GetSituacaoMensagem() => Nota.HasValue ? Situacao == EnumStatusFinal.Aprovado ? "Aprovado"
                   : Situacao == EnumStatusFinal.Recuperacao ? "Recuperação"
                   : "Reprovado"
                   : "Sem notas";
    }
}
