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


        public async Task<object> CallService(ISendService service,EnumTipoSendService tipoService, IBaseViewModel model = null)
        {
            var result = await service.SendService(model);
            OperacaoValida(tipoService);
            return result;
        }

        public bool OperacaoValida(EnumTipoSendService tipoService)
        {
            AddNotificaoPeloTipoServico(tipoService);
            if(_notificador.Value.ContemMensagens())
            {
                var mensagem = _notificador.Value.Mensagens().FirstOrDefault();
                switch (mensagem.Tipo)
                {
                    case EnumTipoMensagem.Erro:
                        _toastService.ShowError(mensagem?.Mensagem, "Ocorreu um erro!"); break;
                    case EnumTipoMensagem.Warning:
                        _toastService.ShowWarning(mensagem?.Mensagem, "Atenção!"); break;
                    case EnumTipoMensagem.Sucesso:
                        _toastService.ShowSuccess(mensagem?.Mensagem, "Sucesso!"); break;
                    default:
                        break;
                }
            }
            _notificador.Value.Limpar();
            return _notificador.Value.IsValido();
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
    }
}
