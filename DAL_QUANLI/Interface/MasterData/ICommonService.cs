using DAL_QUANLI.Models.Common;
using DAL_QUANLI.Models.DataDB;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface.MasterData
{
    public interface ICommonService
    {
        public List<dynamic> ExcuteStringQuery(QueryCommonModel model);
        public StatusMessage<string> FilterListDataAnyTable(HttpRequest httpRequest,  QueryCommonModel model);
        public void LogTime<T>(HttpRequest httpRequest, string table_name, string action, StatusMessage<T> message);
    }
}
