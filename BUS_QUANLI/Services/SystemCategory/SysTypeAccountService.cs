using DAL_QUANLI.Interface;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services.SystemCategory
{
    public class SysTypeAccountService : rootCommonService, ISysTypeAccount
    {
        public string _tableName = "SysTypeAccount";

        public StatusMessage<SysTypeAccount> Delete(HttpRequest httpRequest, SysTypeAccount model)
        {
            try
            {
                var result = dataContext.SysTypeAccounts.Where(x => x.code == model.code).ToList();

                if (result.Count > 0)
                {
                    dataContext.SysTypeAccounts.RemoveRange(result);
                    dataContext.SaveChanges();
                    return new StatusMessage<SysTypeAccount>(0, GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), model);
                }
                else
                {
                    return new StatusMessage<SysTypeAccount>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<SysTypeAccount>(1, GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), model);
            }
        }

        public StatusMessage<SysTypeAccount> Insert(HttpRequest httpRequest, SysTypeAccount model)
        {
            try
            {
                if (model.name == null)
                {
                    return new StatusMessage<SysTypeAccount>(1, GetMessageDescription(EnumQuanLi.DataNoName, httpRequest), model);
                }
                else
                {

                    model.code = commonHelpers.GenerateRowID(_tableName);
                    dataContext.SysTypeAccounts.Add(model);
                    dataContext.SaveChanges();
                    return new StatusMessage<SysTypeAccount>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<SysTypeAccount>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest));
            }
        }

        public StatusMessage<List<SysTypeAccount>> Search(HttpRequest httpRequest, SysTypeAccount model)
        {
            try
            {
                var result = dataContext.SysTypeAccounts.Where(x => (model.code == null || x.code == model.code)).ToList();
                return new StatusMessage<List<SysTypeAccount>>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<SysTypeAccount>>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest), new List<SysTypeAccount>());
            }
        }

        public StatusMessage<SysTypeAccount> Update(HttpRequest httpRequest, SysTypeAccount model)
        {
            try
            {
                var result = dataContext.SysPermissions.Where(x => x.code == model.code).OrderBy(x => x.order_number).ToList();

                if (result.Count > 0)
                {


                    if (model.code == null)
                    {
                        return new StatusMessage<SysTypeAccount>(1, GetMessageDescription(EnumQuanLi.DataNoCode, httpRequest), model);
                    }
                    else if (model.name == null)
                    {
                        return new StatusMessage<SysTypeAccount>(1, GetMessageDescription(EnumQuanLi.DataNoName, httpRequest), model);
                    }
                    else
                    {
                        dataContext.RemoveRange(result);
                        dataContext.SysTypeAccounts.Add(model);
                        dataContext.SaveChanges();
                        return new StatusMessage<SysTypeAccount>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), model);
                    }
                }
                else
                {
                    return new StatusMessage<SysTypeAccount>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), model);
                }
            }
            catch
            {
                return new StatusMessage<SysTypeAccount>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), model);
            }
        }
    }
}
