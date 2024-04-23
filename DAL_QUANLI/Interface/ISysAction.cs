using DAL_QUANLI.Models.SystemDB.SysAction;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;

namespace DAL_QUANLI.Interface
{
    public interface ISysAction
    {
        Task<StatusMessage<SysAction>> SysActionInsert(SysAction p, HttpRequest httpRequest);
        Task<StatusMessage<dynamic>> SysActionUpadte(SysAction p, HttpRequest httpRequest);
        Task<SysAction> SysActionGetByCode(string code);
        Task<List<SysAction>> SysActiongetByCode(string code, HttpRequest httpRequest);
        Task<List<SysAction>> SysActionGetByCode_AccessPermision(string code, HttpRequest httpRequest);
        Task<StatusMessage<dynamic>> SysActionDelete(SysAction p, HttpRequest httpRequest);

    }
}
