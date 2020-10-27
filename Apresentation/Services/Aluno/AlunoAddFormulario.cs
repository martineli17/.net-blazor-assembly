using Dominio.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Services.Aluno
{
    public class AlunoAddFormulario
    {
        private readonly IAlunoService _alunoService;
        public AlunoAddFormulario(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }
    }
}
