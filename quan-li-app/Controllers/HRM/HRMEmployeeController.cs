using BUS_QUANLI.Services.HRM;
using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Models.CustomModel.HRM;
using DAL_QUANLI.Models.DataDB.Movie.Transaction;
using DAL_QUANLI.Models.DataDB.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quan_li_app.Models.Common;

namespace quan_li_app.Controllers.HRM
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRMEmployeeController : ControllerBase
    {
        private readonly HRM_Employee_Service employeeService;
        private readonly CommonService commonService;

        public HRMEmployeeController()
        {
            this.employeeService = new HRM_Employee_Service();
            this.commonService = new CommonService();
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<StatusMessage<HRM_Employee_Model>>> Insert(HRM_Employee_Model model)
        {
            var res = this.employeeService.Insert(this.Request, model);
            this.commonService.LogTime<HRM_Employee_Model>(this.Request, this.employeeService._TableName, "Insert Movie", res);
            return res;
        }


        [HttpPost("Get")]
        public async Task<ActionResult<StatusMessage<HRM_Employee_Model>>> Get(HRM_Employee_Model model)
        {
            var res = this.employeeService.Get(this.Request, model);
            this.commonService.LogTime<HRM_Employee_Model>(this.Request, this.employeeService._TableName, "Get Movie", res);
            return res;
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<StatusMessage<HRM_Employee_Model>>> Delete(HRM_Employee_Model model)
        {
            var res = this.employeeService.Delete(this.Request, model);
            this.commonService.LogTime<HRM_Employee_Model>(this.Request, this.employeeService._TableName, "Delete Movie", res);
            return res;
        }

        [HttpPost("Search")]
        public async Task<ActionResult<StatusMessage<List<HRM_Employee_Model>>>> Search(HRM_Employee_Model model)
        {
            var res = this.employeeService.Search(this.Request, model);
            this.commonService.LogTime<List<HRM_Employee_Model>>(this.Request, this.employeeService._TableName, "Search Movie", res);
            return res;
        }

        [HttpPost("Update")]
        public async Task<ActionResult<StatusMessage<HRM_Employee_Model>>> Update(HRM_Employee_Model model)
        {
            var res = this.employeeService.Update(this.Request, model);
            this.commonService.LogTime<HRM_Employee_Model>(this.Request, this.employeeService._TableName, "Update Movie", res);
            return res;
        }

    }
}
