using System;

namespace Apresentation.ViewModels.AlunoDisciplinaViewModel
{
    public abstract class AlunoDisciplinaBaseViewModel : IBaseViewModel
    {
        public double? Nota { get; set; } = null;
        public Guid IdAluno { get; set; } = Guid.Empty;
        public Guid IdDisciplina { get; set; } = Guid.Empty;
    }
}
