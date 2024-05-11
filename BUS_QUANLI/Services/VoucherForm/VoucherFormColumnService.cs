using DAL_QUANLI.Interface;
using DAL_QUANLI.Models.SystemDB.SysVoucherForm;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services.VoucherForm
{
    public class VoucherFormColumnService : rootCommonService, IVoucherFormServiceColumn
    {
        public async Task<StatusMessage<SysVoucherFormColumn>> Delete(HttpRequest httpRequest, SysVoucherFormColumn sysVoucherFormColumn)
        {
            try
            {
                if (sysVoucherFormColumn.id is null || sysVoucherFormColumn.id.Length == 0)
                {
                    return new StatusMessage<SysVoucherFormColumn>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }
                
                var oldRow = systemContext.SysVoucherFormColumns.Find(sysVoucherFormColumn.id);

                if (oldRow is not null)
                {
                    systemContext.SysVoucherFormColumns.Remove(oldRow);
                    systemContext.SaveChanges();
                    return new StatusMessage<SysVoucherFormColumn>(0, GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), sysVoucherFormColumn);

                }
                else
                {
                    return new StatusMessage<SysVoucherFormColumn>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }

            }
            catch
            {
                return new StatusMessage<SysVoucherFormColumn>(1, GetMessageDescription(EnumQuanLi.DeleteError, httpRequest));
            }
        }

        public async Task<StatusMessage<SysVoucherFormColumn>> Insert(HttpRequest httpRequest, SysVoucherFormColumn sysVoucherFormColumn)
        {
            try
            {
                if (sysVoucherFormColumn.code is null || sysVoucherFormColumn.code.Length == 0)
                {
                    return new StatusMessage<SysVoucherFormColumn>(1, GetMessageDescription(EnumQuanLi.VoucherFormNotCode, httpRequest));
                }
                else if (sysVoucherFormColumn.table_name is null || sysVoucherFormColumn.table_name.Length == 0)
                {
                    return new StatusMessage<SysVoucherFormColumn>(1, GetMessageDescription(EnumQuanLi.VoucherFormNotTable, httpRequest));
                }

                sysVoucherFormColumn.id = commonHelpers.GenerateRowID("SysVoucherFormColumn", sysVoucherFormColumn.companyCode is not null ? sysVoucherFormColumn.companyCode : "");
                systemContext.SysVoucherFormColumns.Add(sysVoucherFormColumn);
                systemContext.SaveChanges();

                var result = systemContext.SysVoucherFormColumns.Find(sysVoucherFormColumn.id);


                if (result != null)
                {
                    return new StatusMessage<SysVoucherFormColumn>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), result);
                }
                else
                {
                    return new StatusMessage<SysVoucherFormColumn>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest));
                }
            }
            catch
            {
                return new StatusMessage<SysVoucherFormColumn>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest));
            }

        }

        public async Task<StatusMessage<List<SysVoucherFormColumn>>> Search(HttpRequest httpRequest, SysVoucherFormColumn sysVoucherFormColumn)
        {
            try
            {

                var getRow = systemContext.SysVoucherFormColumns.Where(x => (
                        (x.table_name == sysVoucherFormColumn.table_name || sysVoucherFormColumn.table_name == null)
                    &&
                        (x.code == sysVoucherFormColumn.code || sysVoucherFormColumn.code == null)
                    &&
                        (x.id == x.id || x.id == null)
                )).ToList();
                return new StatusMessage<List<SysVoucherFormColumn>>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), getRow);
            }
            catch
            {
                return new StatusMessage<List<SysVoucherFormColumn>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<SysVoucherFormColumn>());
            }
        }

        public async Task<StatusMessage<SysVoucherFormColumn>> Update(HttpRequest httpRequest, SysVoucherFormColumn sysVoucherFormColumn)
        {
            try
            {
                if (sysVoucherFormColumn.id is null || sysVoucherFormColumn.id.Length == 0)
                {
                    return new StatusMessage<SysVoucherFormColumn>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }
                else if (sysVoucherFormColumn.code is null || sysVoucherFormColumn.code.Length == 0)
                {
                    return new StatusMessage<SysVoucherFormColumn>(1, GetMessageDescription(EnumQuanLi.VoucherFormNotCode, httpRequest));
                }
                else if (sysVoucherFormColumn.table_name is null || sysVoucherFormColumn.table_name.Length == 0)
                {
                    return new StatusMessage<SysVoucherFormColumn>(1, GetMessageDescription(EnumQuanLi.VoucherFormNotTable, httpRequest));
                }

                var oldRow = systemContext.SysVoucherFormColumns.Find(sysVoucherFormColumn.id);

                if (oldRow is not null)
                {
                    systemContext.SysVoucherFormColumns.Remove(oldRow);
                    systemContext.SysVoucherFormColumns.Add(sysVoucherFormColumn);
                    systemContext.SaveChanges();
                    return new StatusMessage<SysVoucherFormColumn>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), sysVoucherFormColumn);

                }
                else
                {
                    return new StatusMessage<SysVoucherFormColumn>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }

            }
            catch
            {
                return new StatusMessage<SysVoucherFormColumn>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest));
            }
        }
    }
}
