using DAL_QUANLI.Models.SystemDB.SysVoucherForm;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface
{
    public interface IVoucherFormServiceColumn
    {
        public Task<StatusMessage<SysVoucherFormColumn>> Insert(HttpRequest httpRequest, SysVoucherFormColumn sysVoucherFormColumn);
        public Task<StatusMessage<SysVoucherFormColumn>> Update(HttpRequest httpRequest, SysVoucherFormColumn sysVoucherFormColumn);
        public Task<StatusMessage<SysVoucherFormColumn>> Delete(HttpRequest httpRequest, SysVoucherFormColumn sysVoucherFormColumn);
        public Task<StatusMessage<List<SysVoucherFormColumn>>> Search(HttpRequest httpRequest, SysVoucherFormColumn sysVoucherFormColumn);
    }
}
