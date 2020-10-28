using Apresentation.Enums;
using Apresentation.ViewModels;
using System.Threading.Tasks;

namespace Apresentation.Services.Base
{
    public interface ISendService
    {
        Task<bool> SendService(IBaseViewModel model);
    }
}
