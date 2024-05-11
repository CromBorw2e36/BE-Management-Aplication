using DAL_QUANLI.Interface;
using DAL_QUANLI.Models.SystemDB;
using DAL_QUANLI.Models.SystemDB.SysVoucherForm;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services
{
    public class SysGenRowTableService : rootCommonService, ISysGenRowTable
    {
        public StatusMessage<SysGenRowTable> Delete(HttpRequest httpRequest, SysGenRowTable sysGenRowTable)
        {
            try
            {
                if (sysGenRowTable.id is null || sysGenRowTable.id.Length == 0)
                {
                    return new StatusMessage<SysGenRowTable>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), sysGenRowTable);
                }

                var result = systemContext.SysGenRowTables.Find(sysGenRowTable.id);
                if (result is not null)
                {
                    systemContext.SysGenRowTables.Remove(result);
                    systemContext.SaveChanges();
                    return new StatusMessage<SysGenRowTable>(0, GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), sysGenRowTable);
                }

                return new StatusMessage<SysGenRowTable>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
            }
            catch
            {
                return new StatusMessage<SysGenRowTable>(1, GetMessageDescription(EnumQuanLi.DeleteError, httpRequest));
            }
        }

        public StatusMessage<SysGenRowTable> Insert(HttpRequest httpRequest, SysGenRowTable sysGenRowTable)
        {
            try
            {
                if (sysGenRowTable.dataField is null || sysGenRowTable.dataField.Length == 0)
                {
                    return new StatusMessage<SysGenRowTable>(1, GetMessageDescription(EnumQuanLi.GenRowTableNotDataField, httpRequest), sysGenRowTable);
                }
                else if (sysGenRowTable.dataType is null || sysGenRowTable.dataType.Length == 0)
                {
                    return new StatusMessage<SysGenRowTable>(1, GetMessageDescription(EnumQuanLi.GenRowTableNotDataType, httpRequest), sysGenRowTable);
                }
                else if (sysGenRowTable.table_name is null || sysGenRowTable.table_name.Length == 0)
                {
                    return new StatusMessage<SysGenRowTable>(1, GetMessageDescription(EnumQuanLi.GenRowTableNotTable, httpRequest), sysGenRowTable);
                }

                sysGenRowTable.id = commonHelpers.GenerateRowID("SysGenRowTable", sysGenRowTable.companyCode ?? "");
                systemContext.SysGenRowTables.Add(sysGenRowTable);
                systemContext.SaveChanges();
                return new StatusMessage<SysGenRowTable>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), sysGenRowTable);

            }
            catch
            {
                return new StatusMessage<SysGenRowTable>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest));
            }
        }

        public StatusMessage<List<SysGenRowTable>> Search(HttpRequest httpRequest, SysGenRowTable sysGenRowTable)
        {
            try
            {

                //if (sysGenRowTable.id is null || sysGenRowTable.id.Length == 0)
                //{
                //    return new StatusMessage<List<SysGenRowTable>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<SysGenRowTable>());
                //}


                var result = systemContext.SysGenRowTables.Where(x => (
                (x.id == sysGenRowTable.id) || sysGenRowTable.id == null || sysGenRowTable.id.Length == 0)
                && (x.table_name == sysGenRowTable.table_name || sysGenRowTable.table_name == null)
                && (x.dataField == sysGenRowTable.dataField || sysGenRowTable.dataField == null)).ToList();

                return new StatusMessage<List<SysGenRowTable>>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<SysGenRowTable>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), sysGenRowTable);
            }
        }

        public StatusMessage<SysGenRowTable> Update(HttpRequest httpRequest, SysGenRowTable sysGenRowTable)
        {
            try
            {
                if (sysGenRowTable.id is null || sysGenRowTable.id.Length == 0)
                {
                    return new StatusMessage<SysGenRowTable>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), sysGenRowTable);
                }

                var result = systemContext.SysGenRowTables.Find(sysGenRowTable.id);
                if (result is not null)
                {
                    systemContext.SysGenRowTables.Remove(result);
                    systemContext.SysGenRowTables.Add(sysGenRowTable);
                    systemContext.SaveChanges();
                    return new StatusMessage<SysGenRowTable>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), sysGenRowTable);
                }

                return new StatusMessage<SysGenRowTable>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
            }
            catch
            {
                return new StatusMessage<SysGenRowTable>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest));
            }
        }
    }
}
