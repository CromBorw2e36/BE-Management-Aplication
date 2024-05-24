using DAL_QUANLI.Models.SystemDB;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface.MasterData
{
    public interface ISysGenRowTableService
    {
        public StatusMessage<SysGenRowTable> Insert(HttpRequest httpRequest, SysGenRowTable sysGenRowTable);
        public StatusMessage<SysGenRowTable> Update(HttpRequest httpRequest, SysGenRowTable sysGenRowTable);
        public StatusMessage<SysGenRowTable> Delete(HttpRequest httpRequest, SysGenRowTable sysGenRowTable);
        public StatusMessage<List<SysGenRowTable>> Search(HttpRequest httpRequest, SysGenRowTable sysGenRowTable);
        public void LogTime<T>(HttpRequest httpRequest, string action, StatusMessage<T> message);
    }
}
