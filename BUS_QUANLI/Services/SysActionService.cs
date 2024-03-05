using DAL_QUANLI.Models.SystemDB.SysAction;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.ViewModels.Data;

namespace BUS_QUANLI.Services
{
    public class SysActionService
    {
        private readonly DataContext dataContext;
        private readonly SystemContext systemContext;
        private readonly CommonHelpers commonHelpers;
        private readonly ViewModelAccount viewModelAccount;
        private readonly TokenHelper tokenHelper;
        private readonly StatusMessageMapper statusMessageMapper;

        public SysActionService()
        {
            this.dataContext = new DataContext();
            this.systemContext = new SystemContext();
            this.viewModelAccount = new ViewModelAccount(dataContext);
            this.commonHelpers = new CommonHelpers();
            this.tokenHelper = new TokenHelper(dataContext);
            this.statusMessageMapper = new StatusMessageMapper();

        }

        public async Task<StatusMessage> insert(SysAction p)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@pcode", p.code));
            parameters.Add(new SqlParameter("@pnameVn", p.nameVn));
            parameters.Add(new SqlParameter("@pnameOther", p.nameOther));
            parameters.Add(new SqlParameter("@pcolor", p.color));
            parameters.Add(new SqlParameter("@pbackgroundColor", p.backgroundColor));
            parameters.Add(new SqlParameter("@pisDisable", p.isDisable));
            parameters.Add(new SqlParameter("@pdescription", p.description));
            parameters.Add(new SqlParameter("@purl_1", p.url_1));
            parameters.Add(new SqlParameter("@purl_2", p.url_2));
            parameters.Add(new SqlParameter("@purl_3", p.url_3));
            parameters.Add(new SqlParameter("@purl_4", p.url_4));
            StatusMessage result = this.systemContext.Database.SqlQueryRaw<StatusMessage>
                ("EXEC spSysActionIns @pcode ,@pnameVn ,@pnameOther ,@picon ,@pcolor ,@pbackgroundColor ,@pisDisable ,@pdescription ,@purl_1 ,@purl_2 ,@purl_3 ,@purl_4 ", parameters.ToArray()).FirstOrDefault();
            SysAction data = await this.getByCode(result.currentID);
            if (result == null)
            {
                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertError));
                return message;
            }
            else if (result.status == 0)
            {
                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertError), data, result.currentID);
                return message;
            }
            else if (result.status == 1)
            {
                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertSuccess), data, result.currentID);
                return message;
            }
            return null;
        }

        public async Task<StatusMessage> update(SysAction p)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@pcode", p.code));
            parameters.Add(new SqlParameter("@pnameVn", p.nameVn));
            parameters.Add(new SqlParameter("@pnameOther", p.nameOther));
            parameters.Add(new SqlParameter("@picon", p.icon));
            parameters.Add(new SqlParameter("@pcolor", p.color));
            parameters.Add(new SqlParameter("@pbackgroundColor", p.backgroundColor));
            parameters.Add(new SqlParameter("@pisDisable", p.isDisable));
            parameters.Add(new SqlParameter("@pdescription", p.description));
            parameters.Add(new SqlParameter("@purl_1", p.url_1));
            parameters.Add(new SqlParameter("@purl_2", p.url_2));
            parameters.Add(new SqlParameter("@purl_3", p.url_3));
            parameters.Add(new SqlParameter("@purl_4", p.url_4));
            StatusMessage result = this.systemContext.Database.SqlQueryRaw<StatusMessage>
                ("EXEC spSysActionUpd @pcode ,@pnameVn ,@pnameOther ,@picon ,@pcolor ,@pbackgroundColor ,@pisDisable ,@pdescription ,@purl_1 ,@purl_2 ,@purl_3 ,@purl_4 ", parameters.ToArray()).FirstOrDefault();
            SysAction data = await this.getByCode(result.currentID);
            if (result == null)
            {
                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertError), p, p.code);
                return message;
            }
            else if (result.status == 0)
            {
                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertError), data, result.currentID);
                return message;
            }
            else if (result.status == 1)
            {
                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertSuccess), data, result.currentID);
                return message;
            }
            return null;
        }

        public async Task<List<SysAction>> get(SysAction p)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@pcode", p.code));
            parameters.Add(new SqlParameter("@startRowIndex", null));
            parameters.Add(new SqlParameter("@pageSize", null));
            List<SysAction> result = this.systemContext.Database.SqlQueryRaw<SysAction>("EXEC spSysActionUpd @pcode ,@startRowIndex ,@pageSize ", parameters.ToArray()).ToList();
            return result;
        }

        public async Task<SysAction> getByCode(string code = "")
        {
            if (code.Length == 0)
            {
                return null;
            }
            else
            {
                var data = await this.get(new SysAction
                {
                    code = code
                });
                return data[0];
            }
        }


    }
}
