using DAL_QUANLI.Interface.MasterData;
using DAL_QUANLI.Models.Common;
using DAL_QUANLI.Models.CustomModel;
using DAL_QUANLI.Models.DataDB;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services.MasterData
{
    public class CommonService : rootCommonService, ICommonService
    {
        public List<dynamic> ExcuteStringQuery(QueryCommonModel model)
        {
            var stringQuery = model.string_query;

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@pstring_query", stringQuery));

            var result = dataContext.Database.SqlQueryRaw<QueryComboBoxModel>(
            "EXEC ExcuteStringQuery @pstring_query", parameters.ToArray()
            ).ToList();

            List<object> list = new List<object>();
            list.AddRange(result);

            return list;
        }

        public StatusMessage<string> FilterListDataAnyTable(HttpRequest httpRequest, QueryCommonModel model)
        {
            try
            {
                var stringQuery = model.string_query;
                var userName = tokenHelper.GetUsername(httpRequest);

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@p_string_query", stringQuery),
                    new SqlParameter("@p_user_name", userName ?? (object)DBNull.Value) // Handle NULL user name
                };

                var result = dataContext.Database.SqlQueryRaw<string>(
                    "EXEC FilterListDataAnyTable @p_string_query, @p_user_name", parameters.ToArray()
                ).ToList();

                var jsonResult = String.Join("", result);



                if (jsonResult != null)
                {
                    //var jsonResponse = JsonConvert.DeserializeObject<dynamic>(jsonResult);
                    return new StatusMessage<string>(0, this.GetMessageDescription(quan_li_app.Models.EnumQuanLi.NotFoundItem, httpRequest), jsonResult);
                }
                    return new StatusMessage<string>(1, this.GetMessageDescription(quan_li_app.Models.EnumQuanLi.NotFoundItem, httpRequest));
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if necessary
                return new StatusMessage<string>(1, "An error occurred while processing your request.");
            }
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
