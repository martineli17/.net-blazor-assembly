using Apresentation.ViewModels.AlunoDisciplinaViewModel;
using Apresentation.ViewModels.CursoViewModel;
using System;
using System.Collections.Generic;

namespace Apresentation.ViewModels.AlunoViewModel
{
    public class AlunoGetViewModel : BaseViewModel
    {
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public CursoGetViewModel Curso { get; set; }
        public Guid IdCurso { get; set; }
        public IEnumerable<AlunoDisciplinaGetViewModel> AlunoDisciplina { get; set; }
    }
}
