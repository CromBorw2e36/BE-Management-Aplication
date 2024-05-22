using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface
{
    public interface ISysPermissionService
    {
        StatusMessage<List<SysPermission>> Search(HttpRequest httpRequest, SysPermission model);
        StatusMessage<SysPermission> Insert(HttpRequest httpRequest, SysPermission model);
        StatusMessage<SysPermission> Update(HttpRequest httpRequest, SysPermission model);
        StatusMessage<SysPermission> Delete(HttpRequest httpRequest, SysPermission model);
    }
}
