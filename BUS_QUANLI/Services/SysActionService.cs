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
            this.tokenHelper = new TokenHelper();
            this.statusMessageMapper = new StatusMessageMapper();

        }

        public async Task<StatusMessage> insert(SysAction p)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@pcode", p.code != null ? p.code : DBNull.Value));
            parameters.Add(new SqlParameter("@pnameVn", p.nameVn != null ? p.nameVn : DBNull.Value));
            parameters.Add(new SqlParameter("@pnameOther", p?.nameOther != null ? p.nameOther : DBNull.Value));
            parameters.Add(new SqlParameter("@picon", p?.icon != null ? p.icon : DBNull.Value));
            parameters.Add(new SqlParameter("@pcolor", p?.color != null ? p.color : DBNull.Value));
            parameters.Add(new SqlParameter("@pbackgroundColor", p?.backgroundColor != null ? p.backgroundColor : DBNull.Value));
            parameters.Add(new SqlParameter("@pisDisable", p?.isDisable != null ? p.isDisable : DBNull.Value));
            parameters.Add(new SqlParameter("@pdescription", p.description != null ? p.description : DBNull.Value));
            parameters.Add(new SqlParameter("@purl_1", p?.url_1 != null ? p.url_1 : DBNull.Value));
            parameters.Add(new SqlParameter("@purl_2", p?.url_2 != null ? p.url_2 : DBNull.Value));
            parameters.Add(new SqlParameter("@purl_3", p?.url_3 != null ? p.url_3 : DBNull.Value));
            parameters.Add(new SqlParameter("@purl_4", p?.url_4 != null ? p.url_4 : DBNull.Value));
            var result = this.systemContext.Database.SqlQueryRaw<StatusMessage>(
           "EXEC spSysActionIns @pcode, @pnameVn, @pnameOther, @picon, @pcolor, @pbackgroundColor, @pisDisable, @pdescription, @purl_1, @purl_2, @purl_3, @purl_4", parameters.ToArray()
           ).ToList();
            Console.WriteLine(result.ToString());
            SysAction data = await this.getByCode(result[0].currentID);
            if (result == null)
            {
                return new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertError));
            }
            else if (result[0].status == 0)
            {
                return new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertError));
            }
            else if (result[0].status == 1)
            {
                return new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertSuccess), data, result[0].currentID);
            }
            return new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertError)); ;
        }

        public async Task<StatusMessage> update(SysAction p)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@pcode", p.code != null ? p.code : DBNull.Value));
            parameters.Add(new SqlParameter("@pnameVn", p.nameVn != null ? p.nameVn : DBNull.Value));
            parameters.Add(new SqlParameter("@pnameOther", p?.nameOther != null ? p.nameOther : DBNull.Value));
            parameters.Add(new SqlParameter("@picon", p?.icon != null ? p.icon : DBNull.Value));
            parameters.Add(new SqlParameter("@pcolor", p?.color != null ? p.color : DBNull.Value));
            parameters.Add(new SqlParameter("@pbackgroundColor", p?.backgroundColor != null ? p.backgroundColor : DBNull.Value));
            parameters.Add(new SqlParameter("@pisDisable", p?.isDisable != null ? p.isDisable : DBNull.Value));
            parameters.Add(new SqlParameter("@pdescription", p.description != null ? p.description : DBNull.Value));
            parameters.Add(new SqlParameter("@purl_1", p?.url_1 != null ? p.url_1 : DBNull.Value));
            parameters.Add(new SqlParameter("@purl_2", p?.url_2 != null ? p.url_2 : DBNull.Value));
            parameters.Add(new SqlParameter("@purl_3", p?.url_3 != null ? p.url_3 : DBNull.Value));
            parameters.Add(new SqlParameter("@purl_4", p?.url_4 != null ? p.url_4 : DBNull.Value));
            var result = this.systemContext.Database.SqlQueryRaw<StatusMessage>(
            "EXEC spSysActionUpd @pcode, @pnameVn, @pnameOther, @picon, @pcolor, @pbackgroundColor, @pisDisable, @pdescription, @purl_1, @purl_2, @purl_3, @purl_4", parameters.ToArray())
            .ToList();
            Console.WriteLine(result.ToString());
            SysAction data = await getByCode(result[0].currentID);
            if (result == null)
            {
                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError));
                return message;
            }
            else if (result[0].status == 0)
            {
                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError));
                return message;
            }
            else if (result[0].status == 1)
            {
                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess), data, result[0].currentID);
                return message;
            }
            return new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError)); ;
        }


        public async Task<SysAction> getByCode(string code = "")
        {
            if (code.Length == 0)
            {
                return null;
            }
            else
            {
                SysAction data = systemContext.SysActions.Where(x => x.code == code).FirstOrDefault();
                return data;
            }
        }

        public async Task<StatusMessage> delete(SysAction p)
        {
            SysAction get_action = await this.getByCode(p.code);
            if (get_action != null)
            {
                try
                {
                    systemContext.SysActions.Remove(p);
                    systemContext.SaveChanges();
                    return new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.DeleteSuccess), p.code);
                }
                catch
                {
                    return new StatusMessage(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.DeleteError));
                }
            }
            else
            {
                return new StatusMessage(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotFoundItem));
            }
        }
    }
}
