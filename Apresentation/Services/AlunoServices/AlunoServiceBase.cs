using Apresentation.Services.Base;
using Dominio.Interfaces.Service;
using System;

namespace Apresentation.Services.AlunoServices
{
    public class AlunoServiceBase : ServiceBase
    {
        protected readonly IAlunoService AlunoService;
        public AlunoServiceBase(IAlunoService alunoService, InjectorServiceBaseApresentation injector)
            : base(injector)
        {
            AlunoService = alunoService;
        }
    }
}
