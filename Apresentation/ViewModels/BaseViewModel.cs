using System;
using System.ComponentModel.DataAnnotations;

namespace Apresentation.ViewModels
{
    public class BaseViewModel : IBaseViewModel
    {
        public string Nome { get; set; }
        public Guid Id { get; set; }
    }

    public class BaseAddViewModel : IBaseViewModel
    {
        [Required(ErrorMessage = "Necessário informar o nome do curso.")]
        public string Nome { get; set; }
    }

    public interface IBaseViewModel { };
}
