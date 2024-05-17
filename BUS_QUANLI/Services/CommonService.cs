using DAL_QUANLI.Interface;
using DAL_QUANLI.Models.Common;
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
            List<dynamic> result = new List<dynamic>();
            try
            {
                if(model.string_query.Contains("PMQuanLySys.dbo.")) // Width db PMQuanLySys then chuyen sang db system "select * from PMQuanLySys.dbo.SysMenu"
                {
                    result = systemContext.Database.SqlQueryRaw<dynamic>(model.string_query!).ToList();
                    return result;
                }
                else // Width db system then chuyen sang db PMQuanLySys "select * from SysMenu"
                {
                    result = dataContext.Database.SqlQueryRaw<dynamic>(model.string_query!).ToList();
                    return result;
                }
            }
            catch
            {
                return result;
            }
        }
    }
}
