using Dominio.ValuesType;
using System;

namespace Apresentation.ViewModels.ContaViewModel
{
    public class ContaOperacoesViewModel : IBaseViewModel
    {
        public Guid IdConta { get; set; }
        public Guid IdContaDestino { get; set; }
        public decimal Valor { get; set; }
        public EnumOperacaoConta Operacao { get; set; }
    }
}
