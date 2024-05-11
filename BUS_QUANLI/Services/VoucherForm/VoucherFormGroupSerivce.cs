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
    public class VoucherFormGroupSerivce : rootCommonService, ISysVoucherFormGroup
    {
        public StatusMessage<SysVoucherFormGroup> Delete(HttpRequest httpRequest, SysVoucherFormGroup sysVoucherFormGroup)
        {
            try
            {
                if (sysVoucherFormGroup.id is null || sysVoucherFormGroup.id.Length == 0)
                {
                    return new StatusMessage<SysVoucherFormGroup>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }

                var oldRow = systemContext.SysVoucherFormGroups.Find(sysVoucherFormGroup.id);

                if (oldRow is not null)
                {
                    systemContext.SysVoucherFormGroups.Remove(oldRow);
                    systemContext.SaveChanges();
                    return new StatusMessage<SysVoucherFormGroup>(0, GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), sysVoucherFormGroup);

                }
                else
                {
                    return new StatusMessage<SysVoucherFormGroup>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }

            }
            catch
            {
                return new StatusMessage<SysVoucherFormGroup>(1, GetMessageDescription(EnumQuanLi.DeleteError, httpRequest));
            }
        }

        public StatusMessage<SysVoucherFormGroup> Insert(HttpRequest httpRequest, SysVoucherFormGroup sysVoucherFormGroup)
        {
            try
            {
                if (sysVoucherFormGroup.code is null || sysVoucherFormGroup.code.Length == 0)
                {
                    return new StatusMessage<SysVoucherFormGroup>(1, GetMessageDescription(EnumQuanLi.VoucherFormNotCode, httpRequest));
                }
                else if (sysVoucherFormGroup.table_name is null || sysVoucherFormGroup.table_name.Length == 0)
                {
                    return new StatusMessage<SysVoucherFormGroup>(1, GetMessageDescription(EnumQuanLi.VoucherFormNotTable, httpRequest));
                }

                sysVoucherFormGroup.id = commonHelpers.GenerateRowID("SysVoucherFormGroup", sysVoucherFormGroup.companyCode is not null ? sysVoucherFormGroup.companyCode : "");
                systemContext.SysVoucherFormGroups.Add(sysVoucherFormGroup);
                systemContext.SaveChanges();

                var result = systemContext.SysVoucherFormGroups.Find(sysVoucherFormGroup.id);


                if (result != null)
                {
                    return new StatusMessage<SysVoucherFormGroup>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), result);
                }
                else
                {
                    return new StatusMessage<SysVoucherFormGroup>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest));
                }
            }
            catch
            {
                return new StatusMessage<SysVoucherFormGroup>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest));
            }

        }

        public StatusMessage<List<SysVoucherFormGroup>> Search(HttpRequest httpRequest, SysVoucherFormGroup sysVoucherFormGroup)
        {
            try
            {

                var getRow = systemContext.SysVoucherFormColumns.Where(x => (
                        (x.table_name == sysVoucherFormGroup.table_name || sysVoucherFormGroup.table_name == null)
                    &&
                        (x.code == sysVoucherFormGroup.code || sysVoucherFormGroup.code == null)
                    &&
                        (x.id == x.id || x.id == null)
                )).ToList();

                return new StatusMessage<List<SysVoucherFormGroup>>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), getRow);
            }
            catch
            {
                return new StatusMessage<List<SysVoucherFormGroup>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<SysVoucherFormGroup>());
            }
        }

        public StatusMessage<SysVoucherFormGroup> Update(HttpRequest httpRequest, SysVoucherFormGroup sysVoucherFormGroup)
        {
            try
            {
                if (sysVoucherFormGroup.id is null || sysVoucherFormGroup.id.Length == 0)
                {
                    return new StatusMessage<SysVoucherFormGroup>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }
                else if (sysVoucherFormGroup.code is null || sysVoucherFormGroup.code.Length == 0)
                {
                    return new StatusMessage<SysVoucherFormGroup>(1, GetMessageDescription(EnumQuanLi.VoucherFormNotCode, httpRequest));
                }
                else if (sysVoucherFormGroup.table_name is null || sysVoucherFormGroup.table_name.Length == 0)
                {
                    return new StatusMessage<SysVoucherFormGroup>(1, GetMessageDescription(EnumQuanLi.VoucherFormNotTable, httpRequest));
                }

                var oldRow = systemContext.SysVoucherFormGroups.Find(sysVoucherFormGroup.id);

                if (oldRow is not null)
                {
                    systemContext.SysVoucherFormGroups.Remove(oldRow);
                    systemContext.SysVoucherFormGroups.Add(sysVoucherFormGroup);
                    systemContext.SaveChanges();
                    return new StatusMessage<SysVoucherFormGroup>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), sysVoucherFormGroup);
                }
                else
                {
                    return new StatusMessage<SysVoucherFormGroup>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }

            }
            catch
            {
                return new StatusMessage<SysVoucherFormGroup>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest));
            }
        }
    }
}
