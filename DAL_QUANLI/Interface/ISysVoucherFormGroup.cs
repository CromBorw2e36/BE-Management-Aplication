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
    public interface ISysVoucherFormGroup
    {
        public StatusMessage<SysVoucherFormGroup> Insert(HttpRequest httpRequest, SysVoucherFormGroup sysVoucherFormGroup);
        public StatusMessage<SysVoucherFormGroup> Update(HttpRequest httpRequest, SysVoucherFormGroup sysVoucherFormGroup);
        public StatusMessage<SysVoucherFormGroup> Delete(HttpRequest httpRequest, SysVoucherFormGroup sysVoucherFormGroup);
        public StatusMessage<List<SysVoucherFormGroup>> Search(HttpRequest httpRequest, SysVoucherFormGroup sysVoucherFormGroup);
    }
}
