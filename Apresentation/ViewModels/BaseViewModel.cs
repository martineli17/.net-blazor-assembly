using System;
using System.ComponentModel.DataAnnotations;

namespace Apresentation.ViewModels
{
    public class BaseViewModel : BaseAddViewModel, IBaseViewModel
    {
        public Guid Id { get; set; }
    }

    public class BaseAddViewModel : IBaseViewModel
    {
        public string Nome { get; set; }
    }

    public interface IBaseViewModel { };
}
