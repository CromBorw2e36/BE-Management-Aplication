using DAL_QUANLI.Interface;
using DAL_QUANLI.Models.SystemDB.SysAction;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Models;
using quan_li_app.Models.Common;

namespace BUS_QUANLI.Services
{
    public class SysActionService : rootCommonService, ISysAction
    {

        public SysActionService()
        {
        }

        public async Task<StatusMessage<SysAction>> SysActionInsert(SysAction p, HttpRequest httpRequest)
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
            var result = this.systemContext.Database.SqlQueryRaw<StatusMessage<dynamic>>(
           "EXEC spSysActionIns @pcode, @pnameVn, @pnameOther, @picon, @pcolor, @pbackgroundColor, @pisDisable, @pdescription, @purl_1, @purl_2, @purl_3, @purl_4", parameters.ToArray()
           ).ToList();
            SysAction data = await this.SysActionGetByCode(result[0].currentID);
            if (result == null)
            {
                return new StatusMessage<SysAction>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertError, httpRequest));
            }
            else if (result[0].status == 0)
            {
                return new StatusMessage<SysAction>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertError, httpRequest));
            }
            else if (result[0].status == 1)
            {
                return new StatusMessage<SysAction>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertSuccess), data, result[0].currentID);
            }
            return new StatusMessage<SysAction>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InsertError, httpRequest)); ;
        }

        public async Task<StatusMessage<dynamic>> SysActionUpadte(SysAction p, HttpRequest httpRequest)
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
            var result = this.systemContext.Database.SqlQueryRaw<StatusMessage<dynamic>>(
            "EXEC spSysActionUpd @pcode, @pnameVn, @pnameOther, @picon, @pcolor, @pbackgroundColor, @pisDisable, @pdescription, @purl_1, @purl_2, @purl_3, @purl_4", parameters.ToArray())
            .ToList();
            Console.WriteLine(result.ToString());
            SysAction data = await SysActionGetByCode(result[0].currentID);
            if (result == null)
            {
                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError, httpRequest));
                return message;
            }
            else if (result[0].status == 0)
            {
                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError, httpRequest));
                return message;
            }
            else if (result[0].status == 1)
            {
                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), data, result[0].currentID);
                return message;
            }
            return new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError, httpRequest)); ;
        }

        public async Task<SysAction> SysActionGetByCode(string code = "")
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

        // Bảng danh sách các ACITON - ai có quyền menu sẽ thấy
        public async Task<List<SysAction>> SysActiongetByCode(string code = "", HttpRequest? httpRequest = null)
        {
            List<SysAction> lstAction = systemContext.SysActions.Where(x => x.code == code || code == "").ToList();
            return lstAction;
        }

        // Tạm thời làm vậy, chờ phân quyền - Cái này chắc không cần, chỉ cần kiểm tra user có quyền với nút đó ở menu đó không là được
        public async Task<List<SysAction>> SysActionGetByCode_AccessPermision(string code = "", HttpRequest? httpRequest = null)
        {
            List<SysAction> lstAction = systemContext.SysActions.Where(x => x.code == code || code == "").ToList();
            return lstAction;
        }

        public async Task<StatusMessage<dynamic>> SysActionDelete(SysAction p, HttpRequest httpRequest)
        {
            SysAction get_action = await this.SysActionGetByCode(p.code);
            if (get_action != null)
            {
                try
                {
                    systemContext.Remove(get_action);
                    systemContext.SaveChanges();
                    return new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), p.code);
                }
                catch
                {
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.DeleteError, httpRequest));
                }
            }
            else
            {
                return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
            }
        }


    }
}
