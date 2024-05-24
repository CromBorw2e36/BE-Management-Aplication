using DAL_QUANLI.Models.SystemDB.SysAction;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;

namespace DAL_QUANLI.Interface.MasterData
{
    public interface ISysDropDownActionService
    {
        Task<StatusMessage<SysDropDownAction>> SysDropDownActionIns(SysDropDownAction p, HttpRequest httpRequest);
        Task<StatusMessage<SysDropDownAction>> SysDropDownActionUpd(SysDropDownAction p, HttpRequest httpRequest);
        Task<List<SysAction>> SysDropActionGetListSysActionByCode(SysDropDownAction p, HttpRequest httpRequest);
        Task<List<SysDropDownAction>> SysDropActionGet(SysDropDownAction p, HttpRequest httpRequest);
        Task<StatusMessage<dynamic>> SysDropDownActionDel(SysDropDownAction p, HttpRequest httpRequest);
    }
}
