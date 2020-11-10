using Apresentation.Services.AlunoDisciplinaServices;
using Apresentation.Services.AlunoServices;
using Apresentation.Services.Base;
using Apresentation.Services.ClienteServices;
using Apresentation.Services.ContaServices;
using Apresentation.Services.CursoServices;
using Apresentation.Services.DisciplinaServices;
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
            service.TryAddTransient<IClienteRepositorio, ClienteRepositorio>();
            service.TryAddTransient<IContaRepositorio, ContaRepositorio>();
            #endregion

            #region Services
            service.TryAddScoped<InjectorServiceBase>();
            service.TryAddTransient<IValidacaoFluent, ValidacaoFluent>();
            service.TryAddTransient<ICursoService, CursoService>();
            service.TryAddTransient<IAlunoService, AlunoService>();
            service.TryAddTransient<IDisciplinaService, DisciplinaService>();
            service.TryAddTransient<IAlunoDisciplinaService, AlunoDisciplinaService>();
            service.TryAddTransient<IClienteService, ClienteService>();
            service.TryAddTransient<IContaService, ContaService>();
            #endregion

            #region Services front

            #region Curso
            service.TryAddScoped<InjectorServiceBaseApresentation>();
            service.TryAddTransient<ValidatorService>();
            service.TryAddTransient<Services.CursoServices.AddCursoService>();
            service.TryAddTransient<GetCursoService>();
            service.TryAddTransient<RemoveCursoService>();
            service.TryAddTransient<UpdateCursoService>();
            #endregion

            #region Aluno
            service.TryAddTransient<AddAlunoService>();
            service.TryAddTransient<GetAlunoService>();
            service.TryAddTransient<RemoveAlunoService>();
            service.TryAddTransient<UpdateAlunoService>();
            #endregion

            #region Disciplina
            service.TryAddTransient<AddDisciplinaService>();
            service.TryAddTransient<GetDisciplinaService>();
            service.TryAddTransient<UpdateDisciplinaService>();
            service.TryAddTransient<RemoveDisciplinaService>();
            #endregion

            #region Aluno Disciplina
            service.TryAddTransient<AddAlunoDisciplinaService>();
            service.TryAddTransient<GetAlunoDisciplinaServices>();
            service.TryAddTransient<RemoveAlunoDisciplinaServices>();
            service.TryAddTransient<UpdateAlunoDisciplinaService>();
            #endregion

            #region Conta
            service.TryAddTransient<AddContaService>();
            service.TryAddTransient<RemoveContaService>();
            service.TryAddTransient<GetContaService>();
            service.TryAddTransient<OperacoesContaService>();
            #endregion

            #region
            service.TryAddTransient<GetClienteService>();
            service.TryAddTransient<AddClienteService>();
            service.TryAddTransient<RemoveClienteService>();
            service.TryAddTransient<UpdateClienteService>();
            #endregion

            #endregion

            return service;
        }
    }
}
