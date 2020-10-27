using Dominio.ValuesType;
using System.ComponentModel.DataAnnotations;

namespace Apresentation.ViewModels
{
    public class CursoAddViewModel : BaseAddViewModel
    {
        [Required(ErrorMessage = "Necessário informar a Área de Atuação do curso.")]
        public string AreaAtuacao { get; set; }
        [Required(ErrorMessage = "Necessário informar o Turno do curso.")]
        public EnumTurno Turno { get; set; }
        [Required(ErrorMessage = "Necessário informar a Carga Horária do curso.")]
        public double CargaHoraria { get; set; }
    }
}
