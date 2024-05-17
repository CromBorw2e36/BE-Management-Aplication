using DAL_QUANLI.Interface;
using DAL_QUANLI.Models.Common;
using DAL_QUANLI.Models.DataDB;
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
            var result = dataContext.CategoryCommonModels.FromSqlRaw(stringQuery).ToList();
            List<object> list = new List<object>();
            list.AddRange(result);
            return list;
        }
    }
}
