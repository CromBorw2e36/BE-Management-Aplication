using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface.MasterData
{
    public interface ISysTypeAccountService
    {
        StatusMessage<List<SysTypeAccount>> Search(HttpRequest httpRequest, SysTypeAccount model);
        StatusMessage<SysTypeAccount> Insert(HttpRequest httpRequest, SysTypeAccount model);
        StatusMessage<SysTypeAccount> Update(HttpRequest httpRequest, SysTypeAccount model);
        StatusMessage<SysTypeAccount> Delete(HttpRequest httpRequest, SysTypeAccount model);
    }
}
