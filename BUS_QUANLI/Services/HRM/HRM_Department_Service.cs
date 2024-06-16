using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Interface.MasterData;
using DAL_QUANLI.Models.DataDB.QuanLiNhanSu.DanhMuc;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services.HRM
{
    public class HRM_Department_Service : rootCommonService, ICategoryService<DepartmentModel>
    {
        public Task<StatusMessage<DepartmentModel>> Delete(HttpRequest httpRequest, DepartmentModel model)
        {
            throw new NotImplementedException();
        }

        public Task<StatusMessage<DepartmentModel>> Get(HttpRequest httpRequest, DepartmentModel modelt)
        {
            throw new NotImplementedException();
        }

        public Task<StatusMessage<DepartmentModel>> Insert(HttpRequest httpRequest, DepartmentModel model)
        {
            throw new NotImplementedException();
        }

        public Task<StatusMessage<List<DepartmentModel>>> Search(HttpRequest httpRequest, DepartmentModel model)
        {
            throw new NotImplementedException();
        }

        public Task<StatusMessage<DepartmentModel>> Update(HttpRequest httpRequest, DepartmentModel model)
        {
            throw new NotImplementedException();
        }
    }
}
