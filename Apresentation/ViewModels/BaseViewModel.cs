using System;

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

    public class BaseRemoveViewModel : IBaseViewModel
    {
        public Guid Id { get; set; }
    }

    public interface IBaseViewModel { };
}
