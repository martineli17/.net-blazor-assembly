using Apresentation.ViewModels.CursoViewModel;

namespace Apresentation.ViewModels.AlunoViewModel
{
    public class AlunoGetViewModel : BaseViewModel
    {
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public CursoGetViewModel Curso { get; set; }
    }
}
