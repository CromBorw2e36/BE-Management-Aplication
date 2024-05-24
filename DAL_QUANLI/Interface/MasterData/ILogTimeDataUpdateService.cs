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
    public interface ILogTimeDataUpdateService
    {
        StatusMessage<List<LogTimeDataUpdateModel>> Search(HttpRequest httpRequest, LogTimeDataUpdateModel model);
        void Insert(HttpRequest httpRequest, LogTimeDataUpdateModel model);
    }
}
