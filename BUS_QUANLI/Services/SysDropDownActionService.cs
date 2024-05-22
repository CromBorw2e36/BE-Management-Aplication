using DAL_QUANLI.Interface;
using DAL_QUANLI.Models.SystemDB.SysAction;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.Common;

namespace BUS_QUANLI.Services
{
    public class SysDropDownActionService : rootCommonService, ISysDropDownActionService
    {
        public SysDropDownActionService()
        {
        }

        public async Task<List<SysDropDownAction>> SysDropActionGet(SysDropDownAction p, HttpRequest httpRequest)
        {
            try
            {
                List<SysDropDownAction> getListDropDownAction = systemContext.SysDropDownActions.Where(x => x.code == p.code).ToList();
                return getListDropDownAction;
            }
            catch
            {
                return new List<SysDropDownAction>();
            }
        }

        public async Task<List<SysAction>> SysDropActionGetListSysActionByCode(SysDropDownAction p, HttpRequest httpRequest)
        {
            try
            {
                List<SysAction> listSysAction = new List<SysAction>();
                List<SysAction> getListDropDownAction = systemContext.SysDropDownActions
                    .Join(systemContext.SysActions
                    , dropdownAction => dropdownAction.codeAction
                    , action => action.code
                    , (dropdownAction, action) => new
                    {
                        dropdownAction = dropdownAction,
                        action = action
                    })
                    .Where(x => x.dropdownAction.code == p.code)
                    .Select(x => x.action)
                    .ToList();
                return listSysAction;
            }
            catch
            {
                return new List<SysAction>();
            }
        }

        public async Task<StatusMessage<dynamic>> SysDropDownActionDel(SysDropDownAction p, HttpRequest httpRequest)
        {
            SysDropDownAction get_action = systemContext.SysDropDownActions.Where(x => x.code == p.code).FirstOrDefault();
            if (get_action != null)
            {
                try
                {
                    systemContext.Remove(get_action);
                    systemContext.SaveChanges();
                    return new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), p.code);
                }
                catch
                {
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.DeleteError, httpRequest));
                }
            }
            else
            {
                return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
            }
        }

        public async Task<StatusMessage<SysDropDownAction>> SysDropDownActionIns(SysDropDownAction p, HttpRequest httpRequest)
        {
            SysDropDownAction get_action = systemContext.SysDropDownActions.Where(x => x.code == p.code).FirstOrDefault();
            if (get_action == null)
            {
                try
                {
                    systemContext.Add(get_action);
                    systemContext.SaveChanges();
                    return new StatusMessage<SysDropDownAction>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), p);
                }
                catch
                {
                    return new StatusMessage<SysDropDownAction>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertError, httpRequest));
                }
            }
            else
            {
                return new StatusMessage<SysDropDownAction>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.DataExit, httpRequest));
            }
        }

        public async Task<StatusMessage<SysDropDownAction>> SysDropDownActionUpd(SysDropDownAction p, HttpRequest httpRequest)
        {
            SysDropDownAction get_action = systemContext.SysDropDownActions.Where(x => x.code == p.code).FirstOrDefault();
            if (get_action != null)
            {
                try
                {
                    systemContext.Remove(get_action);
                    systemContext.Add(p);
                    systemContext.SaveChanges();
                    return new StatusMessage<SysDropDownAction>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), p);
                }
                catch
                {
                    return new StatusMessage<SysDropDownAction>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError, httpRequest));
                }
            }
            else
            {
                return new StatusMessage<SysDropDownAction>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.DataNotExit, httpRequest));
            }
        }
    }
}
