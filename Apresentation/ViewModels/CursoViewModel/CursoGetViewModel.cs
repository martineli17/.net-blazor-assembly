using Dominio.ValuesType;

namespace Apresentation.ViewModels.CursoViewModel
{
    public class CursoGetViewModel : BaseViewModel
    {
        public string AreaAtuacao { get; set; }
        public double CargaHoraria { get; set; }
        public string Turno { get; set; }
    }

    public class CursoFiltroViewModel : BaseViewModel
    {
        public EnumTurno? Turno { get; set; }
        public string AreaAtuacao { get; set; }
    }
}
