using DAL_QUANLI.Interface;
using DAL_QUANLI.Models.SystemDB.SysAction;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.Common;

namespace BUS_QUANLI.Services
{
    public class SysGroupActionService : rootCommonService, ISysGroupAction
    {
        public SysGroupActionService()
        {
        }

        public async Task<StatusMessage<dynamic>> SysGroupActionIns(SysGroupAction p, HttpRequest httpRequest)
        {
            if (p.code == null || p.code.Length == 0)
            {
                return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
            }
            else if (p.codeAction == null || p.codeAction.Length == 0)
            {
                return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
            }

            try
            {
                SysGroupAction obj = new SysGroupAction()
                {
                    code = p.code,
                    codeAction = p.codeAction,
                    description = p.description,
                    isClocked = p.isClocked,
                    orderNo = p.orderNo,
                    isDropDown = p.isDropDown,
                };
                return new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertError, httpRequest));
            }
        }

        public async Task<List<SysGroupAction>> SysGroupActionGetByCode(string code = "")
        {
            if (code.Length == 0)
            {
                return new List<SysGroupAction>();
            }
            else
            {
                try
                {
                    List<SysGroupAction> data = systemContext.SysGroupAction.Where(x => x.code == code).OrderBy(x => x.orderNo).ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return new List<SysGroupAction>();
                }
            }
        }

        public async Task<StatusMessage<dynamic>> SysGroupActionUpd(SysGroupAction p, HttpRequest httpRequest)
        {
            if (p.code == null || p.code.Length == 0)
            {
                return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
            }
            else if (p.codeAction == null || p.codeAction.Length == 0)
            {
                return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
            }

            SysGroupAction getDropAction = systemContext.SysGroupAction.Where(x => x.code == p.code).FirstOrDefault();
            if (getDropAction != null)
            {
                getDropAction.isClocked = p.isClocked;
                getDropAction.codeAction = p.codeAction;
                getDropAction.orderNo = p.orderNo;

                systemContext.SaveChanges();
                return new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest));
            }
            else
            {
                return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
            }
        }

        public async Task<StatusMessage<dynamic>> SysGroupActionDel(SysAction p, HttpRequest httpRequest)
        {
            SysGroupAction get_action = systemContext.SysGroupAction.Where(x => x.code == p.code).FirstOrDefault();
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

        public async Task<StatusMessage<dynamic>> SysGroupActionIns(List<SysGroupAction> p, HttpRequest httpRequest)
        {
            foreach (var groupActionItem in p)
            {
                StatusMessage<dynamic> res = await SysGroupActionIns(groupActionItem, httpRequest);
                if (res.status == 1)
                {
                    return res;
                }
            }
            return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest));
        }

        public Task<StatusMessage<dynamic>> SysGroupActionUpd(List<SysGroupAction> p, HttpRequest httpRequest)
        {
            throw new NotImplementedException();
        }

        public Task<StatusMessage<dynamic>> SysGroupActionDel(List<SysGroupAction> p, HttpRequest httpRequest)
        {
            throw new NotImplementedException();
        }
    }
}
