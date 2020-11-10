using System;

namespace Apresentation.ViewModels.ContaViewModel
{
    public class ContaAddViewModel : IBaseViewModel
    {
        public Guid IdCliente { get; set; }
        public string NumeroConta { get; set; }
    }
}
