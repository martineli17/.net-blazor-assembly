using Apresentation.Enums;
using Apresentation.Services.Base;
using Apresentation.ViewModels;
using Blazored.Toast.Services;
using Crosscuting.Notificacao;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Apresentation.Services.Validator
{
    public class ValidatorService
    {
        private readonly Lazy<INotificador> _notificador;
        private readonly IToastService _toastService;
        public ValidatorService(Lazy<INotificador> notificador, IToastService toastService)
        {
            _notificador = notificador;
            _toastService = toastService;
        }


        public async Task CallService(IBaseViewModel model, ISendService service, EnumTipoSendService tipoService)
        {
            await service.SendService(model);
            OperacaoValida(tipoService);
        }

        public bool OperacaoValida(EnumTipoSendService tipoService)
        {
            AddNotificaoPeloTipoServico(tipoService);
            var mensagens = _notificador.Value.Mensagens();
            _toastService.ShowWarning(string.Join(" ", mensagens.Select(x => x.Mensagem)),
                mensagens.FirstOrDefault().Tipo == EnumTipoMensagem.Erro ? "Ocorreu um erro!" :
                mensagens.FirstOrDefault().Tipo == EnumTipoMensagem.Sucesso ? "Sucesso!": "Atenção!");
            _notificador.Value.Limpar();
            return false;
        }

        private void AddNotificaoPeloTipoServico(EnumTipoSendService tipoService)
        {
            if (!_notificador.Value.ContemMensagens())
            {
                switch (tipoService)
                {
                    case EnumTipoSendService.Adicionar:
                        _notificador.Value.Add("Registro adicionado com sucesso!", EnumTipoMensagem.Sucesso); break;
                    case EnumTipoSendService.Atualizar:
                        _notificador.Value.Add("Registro atualizado com sucesso!", EnumTipoMensagem.Sucesso); break;
                    case EnumTipoSendService.Excluir:
                        _notificador.Value.Add("Registro removido com sucesso!", EnumTipoMensagem.Sucesso); break;
                    default:
                        break;
                }
            }
        }


        //public bool ValidarDadosFormulario(bool isValid, IEnumerable<string> erros = null)
        //{
        //    if (isValid) return true;
        //    _toastService.ShowWarning(string.Join(". ", erros), "Atenção");
        //    return isValid;
        //}
    }
}
