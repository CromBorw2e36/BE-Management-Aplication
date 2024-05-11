using DAL_QUANLI.Models.SystemDB.SysAction;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;

namespace DAL_QUANLI.Interface
{
    public interface ISysGroupAction
    {
        Task<StatusMessage<dynamic>> SysGroupActionIns(SysGroupAction p, HttpRequest httpRequest);
        Task<StatusMessage<dynamic>> SysGroupActionIns(List<SysGroupAction> p, HttpRequest httpRequest);
        Task<List<SysGroupAction>> SysGroupActionGetByCode(string code = "");
        Task<StatusMessage<dynamic>> SysGroupActionUpd(SysGroupAction p, HttpRequest httpRequest);
        Task<StatusMessage<dynamic>> SysGroupActionUpd(List<SysGroupAction> p, HttpRequest httpRequest);
        Task<StatusMessage<dynamic>> SysGroupActionDel(SysAction p, HttpRequest httpRequest);
        Task<StatusMessage<dynamic>> SysGroupActionDel(List<SysGroupAction> p, HttpRequest httpRequest);

        StatusMessage<List<SysAction>> GetListActionByGroupCode(SysGroupAction groupAction, HttpRequest httpRequest);
    }
}
