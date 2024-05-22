using DAL_QUANLI.Interface;
using DAL_QUANLI.Models.Common;
using DAL_QUANLI.Models.CustomModel;
using DAL_QUANLI.Models.DataDB;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services
{
    public class CommonService : rootCommonService, ICommonService
    {
        public List<dynamic> ExcuteStringQuery(QueryCommonModel model)
        {
            var stringQuery = model.string_query;

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@pstring_query", stringQuery));

            var result = this.dataContext.Database.SqlQueryRaw<QueryComboBoxModel>(
            "EXEC ExcuteStringQuery @pstring_query", parameters.ToArray()
            ).ToList();

            List<object> list = new List<object>();
            list.AddRange(result);

            return list;
        }

        public void LogTime<T>(HttpRequest httpRequest, string table_name, string action, StatusMessage<T> message)
        {
            logTimeDataUpdateService.Insert(httpRequest, new LogTimeDataUpdateModel
            {
                table_name = table_name,
                action_name = action,
                status = message.status == 0 ? "SUCCESED" : "ERRORED",
                notes = message.msg,
            });
        }
    }
}
