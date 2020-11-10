using Apresentation.ViewModels.ClienteViewModel;
using System;

namespace Apresentation.ViewModels.ContaViewModel
{
    public class ContaGetViewModel : ContaAddViewModel
    {
        public Guid Id { get; private set; }
        public decimal Saldo { get;  set; }
        public ClienteGetViewModel Cliente { get; private set; }
    }
}
