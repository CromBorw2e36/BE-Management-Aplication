using DAL_QUANLI.Models.DataDB;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Helpers;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QUANLI.Interface.MasterData;

namespace BUS_QUANLI.Services.MasterData
{
    public class LogTimeDataUpdateService : ILogTimeDataUpdateService
    {


        public readonly DataContext dataContext;
        public readonly TokenHelper tokenHelper;
        public readonly StatusMessageMapper statusMessageMapper;



        public LogTimeDataUpdateService()
        {
            dataContext = new DataContext();
            statusMessageMapper = new StatusMessageMapper();
            tokenHelper = new TokenHelper();
        }

        public string GetMessageDescription(EnumQuanLi param, HttpRequest httpRequest)
        {
            return statusMessageMapper.GetMessageDescription(param, httpRequest);
        }

        public void Insert(HttpRequest httpRequest, LogTimeDataUpdateModel model)
        {
            model.account = tokenHelper.GetUsername(httpRequest);
            try
            {
                model.companyCode = dataContext.Accounts.Where(x => x.account == model.account).FirstOrDefault()!.companyCode;
            }
            catch { }

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ptable_name", model.table_name != null ? model.table_name : DBNull.Value));
            parameters.Add(new SqlParameter("@paction_name", model.action_name != null ? model.action_name : DBNull.Value));
            parameters.Add(new SqlParameter("@paccount", model.account != null ? model.account : DBNull.Value));
            parameters.Add(new SqlParameter("@pstatus", model.status != null ? model.status : DBNull.Value));
            parameters.Add(new SqlParameter("@pcompanyCode", model.companyCode != null ? model.companyCode : DBNull.Value));
            parameters.Add(new SqlParameter("@pnotes", model.notes != null ? model.notes : DBNull.Value));
            try
            {
                var result = dataContext.Database.SqlQueryRaw<StatusMessage<dynamic>>(
               "EXEC LogTimeDataUpdateIns @ptable_name, @paction_name, @paccount, @pstatus, @pcompanyCode, @pnotes", parameters.ToArray())
               .ToList();
            }
            catch { }
        }

        public StatusMessage<List<LogTimeDataUpdateModel>> Search(HttpRequest httpRequest, LogTimeDataUpdateModel model)
        {
            if (model.create_date is null)
                return new StatusMessage<List<LogTimeDataUpdateModel>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<LogTimeDataUpdateModel>());

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ptable_name", model.table_name != null ? model.table_name : DBNull.Value));
            parameters.Add(new SqlParameter("@paction_name", model.action_name != null ? model.action_name : DBNull.Value));
            parameters.Add(new SqlParameter("@paccount", model.account != null ? model.account : DBNull.Value));
            parameters.Add(new SqlParameter("@pstatus", model.status != null ? model.status : DBNull.Value));
            parameters.Add(new SqlParameter("@pcompanyCode", model.companyCode != null ? model.companyCode : DBNull.Value));
            parameters.Add(new SqlParameter("@pnotes", model.notes != null ? model.notes : DBNull.Value));
            parameters.Add(new SqlParameter("@pcreate_date", model.create_date != null ? model.create_date : DBNull.Value));
            try
            {
                var result = dataContext.Database.SqlQueryRaw<LogTimeDataUpdateModel>(
               "EXEC LogTimeDataUpdateIns @ptable_name, @paction_name, @paccount, @pstatus, @pcompanyCode, @pnotes, @pcreate_date", parameters.ToArray())
               .ToList();
                return new StatusMessage<List<LogTimeDataUpdateModel>>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<LogTimeDataUpdateModel>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<LogTimeDataUpdateModel>());

            }
        }
    }
}
