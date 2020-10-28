using Apresentation.Services.Base;
using Apresentation.Services.CursoServices.Interface;
using Apresentation.Services.CursoServices.Servicos;
using Apresentation.Services.Validator;
using Crosscuting.Notificacao;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            service.TryAddScoped<IUnitOfWork, UnitOfWork>();
            service.TryAddScoped<ICursoRepositorio, CursoRepositorio>();
            service.TryAddScoped<IAlunoRepositorio, AlunoRepositorio>();
            service.TryAddScoped<IDisciplinaRepositorio, DisciplinaRepositorio>();
            service.TryAddScoped<IAlunoDisciplinaRepositorio, AlunoDisciplinaRepositorio>();
            #endregion

            #region Services
            service.TryAddScoped<InjectorServiceBase>();
            service.TryAddScoped<IValidacaoFluent, ValidacaoFluent>();
            service.TryAddScoped<ICursoService, CursoService>();
            service.TryAddScoped<IAlunoService, AlunoService>();
            service.TryAddScoped<IDisciplinaService, DisciplinaService>();
            service.TryAddScoped<IAlunoDisciplinaService, AlunoDisciplinaService>();
            #endregion

            #region Services front
            service.TryAddScoped<InjectorServiceBaseApresentation>();
            service.TryAddScoped<AddCursoService>();
            service.TryAddScoped<ValidatorService>();
            #endregion

            return service;
        }
    }
}
