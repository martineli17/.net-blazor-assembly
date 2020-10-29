using Apresentation.Services.Base;
using Apresentation.Services.CursoServices;
using Apresentation.Services.Validator;
using Crosscuting.Notificacao;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Repositorio.Contexto;
using Repositorio.Repositorios;
using Repositorio.UnitOfWork;
using Service.Services;
using Service.Services.ServicesBase;
using Service.Validators.ValidadorBase;
using System;

namespace Apresentation.Configuracoes
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AddInjecaoDependencia(this IServiceCollection service)
        {
            #region CrossCutting
            service.TryAddScoped<INotificador, Notificador>();
            service.TryAddScoped(provider => new Lazy<INotificador>(provider.GetService<INotificador>));
            #endregion

            #region Repositorios
            service.TryAddScoped<Context>();
            service.TryAddTransient<IUnitOfWork, UnitOfWork>();
            service.TryAddTransient<ICursoRepositorio, CursoRepositorio>();
            service.TryAddTransient<IAlunoRepositorio, AlunoRepositorio>();
            service.TryAddTransient<IDisciplinaRepositorio, DisciplinaRepositorio>();
            service.TryAddTransient<IAlunoDisciplinaRepositorio, AlunoDisciplinaRepositorio>();
            #endregion

            #region Services
            service.TryAddScoped<InjectorServiceBase>();
            service.TryAddTransient<IValidacaoFluent, ValidacaoFluent>();
            service.TryAddTransient<ICursoService, CursoService>();
            service.TryAddTransient<IAlunoService, AlunoService>();
            service.TryAddTransient<IDisciplinaService, DisciplinaService>();
            service.TryAddTransient<IAlunoDisciplinaService, AlunoDisciplinaService>();
            #endregion

            #region Services front
            service.TryAddScoped<InjectorServiceBaseApresentation>();
            service.TryAddTransient<ValidatorService>();
            service.TryAddTransient<AddCursoService>();
            service.TryAddTransient<GetCursoService>();
            service.TryAddTransient<RemoveCursoService>();
            service.TryAddTransient<UpdateCursoService>();
            #endregion

            return service;
        }
    }
}
