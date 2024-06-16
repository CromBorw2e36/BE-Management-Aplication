using DAL_QUANLI.Models.CustomModel.HRM;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface.HRM
{
    public interface  I_HRM_Employee_Service
    {
        public StatusMessage<HRM_Employee_Model> Insert(HttpRequest httpRequest, HRM_Employee_Model model);
        public StatusMessage<HRM_Employee_Model> Update(HttpRequest httpRequest, HRM_Employee_Model model);
        public StatusMessage<HRM_Employee_Model> Delete(HttpRequest httpRequest, HRM_Employee_Model model);
        public StatusMessage<HRM_Employee_Model> Get(HttpRequest httpRequest, HRM_Employee_Model model);
        public StatusMessage<List<HRM_Employee_Model>> Search(HttpRequest httpRequest, HRM_Employee_Model model);
    }
}
