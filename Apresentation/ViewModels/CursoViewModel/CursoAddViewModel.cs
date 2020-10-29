using Dominio.ValuesType;
using System.ComponentModel.DataAnnotations;

namespace Apresentation.ViewModels.CursoViewModel
{
    public class CursoAddViewModel : BaseAddViewModel
    {
        public string AreaAtuacao { get; set; }
        public EnumTurno Turno { get; set; }
        public double CargaHoraria { get; set; }
    }
}
