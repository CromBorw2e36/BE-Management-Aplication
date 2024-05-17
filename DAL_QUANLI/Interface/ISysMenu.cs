using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using quan_li_app.Models.SystemDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface
{
    public interface ISysMenu
    {
        public StatusMessage<List<SysMenu>> Search(HttpRequest httpRequest, SysMenu model);
        public StatusMessage<SysMenu> Update(HttpRequest httpRequest, SysMenu model);
        public StatusMessage<SysMenu> Insert(HttpRequest httpRequest, SysMenu model);
        public StatusMessage<dynamic> Delete(HttpRequest httpRequest, SysMenu model);
        public void LogTime<T>(HttpRequest httpRequest, string action, StatusMessage<T> message);

    }
}
