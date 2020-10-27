using System;
using System.ComponentModel.DataAnnotations;

namespace Apresentation.ViewModels
{
    public class BaseViewModel
    {
        public string Nome { get; set; }
        public Guid Id { get; set; }
    }

    public class BaseAddViewModel
    {
        [Required(ErrorMessage = "Necessário informar o nome do curso.")]
        public string Nome { get; set; }
    }
}
