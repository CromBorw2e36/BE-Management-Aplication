using DAL_QUANLI.Models.Common;
using DAL_QUANLI.Models.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface
{
    public interface ICommonService
    {
        public List<dynamic> ExcuteStringQuery(QueryCommonModel model);
    }
}
