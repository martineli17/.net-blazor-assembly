using Apresentation.ViewModels.CursoViewModel;
using System;

namespace Apresentation.ViewModels.DisciplinaViewModel
{
    public class DisciplinaGetViewModel : BaseViewModel
    {
        public Guid IdCurso { get; set; }
        public double CargaHoraria { get; set; }
        public double NotaMinimaAprovacao { get; set; }
        public CursoGetViewModel Curso { get; set; }
    }
}
