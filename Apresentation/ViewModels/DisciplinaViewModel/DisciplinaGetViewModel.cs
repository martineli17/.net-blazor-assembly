using Apresentation.ViewModels.CursoViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
