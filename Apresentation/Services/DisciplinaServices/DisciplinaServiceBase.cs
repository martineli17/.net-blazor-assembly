using Apresentation.Services.Base;
using Dominio.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Services.DisciplinaServices
{
    public class DisciplinaServiceBase : ServiceBase
    {
        protected readonly IDisciplinaService DisciplinaService;

        public DisciplinaServiceBase(IDisciplinaService disciplinaService, InjectorServiceBaseApresentation injector) :
     base(injector)
        {
            DisciplinaService = disciplinaService;
        }
    }
}
