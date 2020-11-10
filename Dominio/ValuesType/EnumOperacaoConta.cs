using System.ComponentModel.DataAnnotations;

namespace Dominio.ValuesType
{
    public enum EnumOperacaoConta
    {
        [Display(Name = "Transferência para outra conta")]
        Transferir = 1,
        [Display(Name = "Depósito")]
        Depositar = 2,
        [Display(Name = "Saque")]
        Sacar = 3,
    }
}
