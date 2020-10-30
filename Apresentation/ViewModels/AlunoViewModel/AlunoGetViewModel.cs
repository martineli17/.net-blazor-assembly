using Apresentation.ViewModels.CursoViewModel;
using System;

namespace Apresentation.ViewModels.AlunoViewModel
{
    public class AlunoGetViewModel : BaseViewModel
    {
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public CursoGetViewModel Curso { get; set; }
    }
}
