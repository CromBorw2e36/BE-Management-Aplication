using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface
{
    public interface ISysStatusService
    {
        StatusMessage<List<SysStatus>> Search(HttpRequest httpRequest, SysStatus model);
        StatusMessage<SysStatus> Insert(HttpRequest httpRequest, SysStatus model);
        StatusMessage<SysStatus> Update(HttpRequest httpRequest, SysStatus model);
        StatusMessage<SysStatus> Delete(HttpRequest httpRequest, SysStatus model);
    }
}
