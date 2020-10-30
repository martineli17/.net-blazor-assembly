using System;

namespace Apresentation.ViewModels.AlunoViewModel
{
    public class AlunoAddViewModel : BaseAddViewModel
    {
        public Guid IdCurso { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; } = DateTime.Now.AddYears(-18);
    }
}
