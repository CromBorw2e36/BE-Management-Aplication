using BUS_QUANLI.Services.HRM;
using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Models.CustomModel.HRM;
using DAL_QUANLI.Models.DataDB.QuanLiNhanSu.DanhMuc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quan_li_app.Models.Common;

namespace quan_li_app.Controllers.HRM
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRM_CommonController : ControllerBase
    {
        private readonly CommonService commonService;
        private readonly HRM_Department_Service hRM_Department_Service;
        private readonly HRM_Position_Service hRM_Position_Service;
        private readonly HRM_StatusEmployee_Service hRM_StatusEmployee_Service;
        private readonly HRM_TypeEmployee_Service hRM_TypeEmployee_Service;
        private readonly HRM_TypeWork_Service hRM_TypeWork_Service;


        public HRM_CommonController()
        {
            this.commonService = new CommonService();
            this.hRM_Department_Service = new HRM_Department_Service();
            this.hRM_Position_Service = new HRM_Position_Service();
            this.hRM_StatusEmployee_Service = new HRM_StatusEmployee_Service();
            this.hRM_TypeEmployee_Service = new HRM_TypeEmployee_Service();
            this.hRM_TypeWork_Service = new HRM_TypeWork_Service();
        }


        [HttpPost("DepartmentInsert")]
        public async Task<ActionResult<StatusMessage<DepartmentModel>>> DepartmentInsert(DepartmentModel model)
        {
            var res = this.hRM_Department_Service.Insert(this.Request, model);
            this.commonService.LogTime<DepartmentModel>(this.Request, this.hRM_Department_Service._tableName, "Insert", res);
            return res;
        }


        [HttpPost("DepartmentGet")]
        public async Task<ActionResult<StatusMessage<DepartmentModel>>> DepartmentGet(DepartmentModel model)
        {
            var res = this.hRM_Department_Service.Get(this.Request, model);
            this.commonService.LogTime<DepartmentModel>(this.Request, this.hRM_Department_Service._tableName, "Get", res);
            return res;
        }

        [HttpPost("DepartmentDelete")]
        public async Task<ActionResult<StatusMessage<DepartmentModel>>> DepartmentDelete(DepartmentModel model)
        {
            var res = this.hRM_Department_Service.Delete(this.Request, model);
            this.commonService.LogTime<DepartmentModel>(this.Request, this.hRM_Department_Service._tableName, "Delete", res);
            return res;
        }

        [HttpPost("DepartmentSearch")]
        public async Task<ActionResult<StatusMessage<List<DepartmentModel>>>> DepartmentSearch(DepartmentModel model)
        {
            var res = this.hRM_Department_Service.Search(this.Request, model);
            this.commonService.LogTime<List<DepartmentModel>>(this.Request, this.hRM_Department_Service._tableName, "Search", res);
            return res;
        }

        [HttpPost("DepartmentUpdate")]
        public async Task<ActionResult<StatusMessage<DepartmentModel>>> DepartmentUpdate(DepartmentModel model)
        {
            var res = this.hRM_Department_Service.Update(this.Request, model);
            this.commonService.LogTime<DepartmentModel>(this.Request, this.hRM_Department_Service._tableName, "Update", res);
            return res;
        }

        // POSTION MODEL

        [HttpPost("PositionInsert")]
        public async Task<ActionResult<StatusMessage<PositionModel>>> PositionInsert(PositionModel model)
        {
            var res = this.hRM_Position_Service.Insert(this.Request, model);
            this.commonService.LogTime<PositionModel>(this.Request, this.hRM_Position_Service._tableName, "Insert", res);
            return res;
        }


        [HttpPost("PositionGet")]
        public async Task<ActionResult<StatusMessage<PositionModel>>> PositionGet(PositionModel model)
        {
            var res = this.hRM_Position_Service.Get(this.Request, model);
            this.commonService.LogTime<PositionModel>(this.Request, this.hRM_Position_Service._tableName, "Get", res);
            return res;
        }

        [HttpPost("PositionDelete")]
        public async Task<ActionResult<StatusMessage<PositionModel>>> PositionDelete(PositionModel model)
        {
            var res = this.hRM_Position_Service.Delete(this.Request, model);
            this.commonService.LogTime<PositionModel>(this.Request, this.hRM_Position_Service._tableName, "Delete", res);
            return res;
        }

        [HttpPost("PositionSearch")]
        public async Task<ActionResult<StatusMessage<List<PositionModel>>>> PositionSearch(PositionModel model)
        {
            var res = this.hRM_Position_Service.Search(this.Request, model);
            this.commonService.LogTime<List<PositionModel>>(this.Request, this.hRM_Position_Service._tableName, "Search", res);
            return res;
        }

        [HttpPost("PositionUpdate")]
        public async Task<ActionResult<StatusMessage<PositionModel>>> PositionUpdate(PositionModel model)
        {
            var res = this.hRM_Position_Service.Update(this.Request, model);
            this.commonService.LogTime<PositionModel>(this.Request, this.hRM_Position_Service._tableName, "Update", res);
            return res;
        }


        // HRM_StatusEmployee_Service

        [HttpPost("StatusEmployeeInsert")]
        public async Task<ActionResult<StatusMessage<StatusEmployeeModel>>> PositionInsert(StatusEmployeeModel model)
        {
            var res = this.hRM_StatusEmployee_Service.Insert(this.Request, model);
            this.commonService.LogTime<StatusEmployeeModel>(this.Request, this.hRM_Position_Service._tableName, "Insert", res);
            return res;
        }


        [HttpPost("StatusEmployeenGet")]
        public async Task<ActionResult<StatusMessage<StatusEmployeeModel>>> PositionGet(StatusEmployeeModel model)
        {
            var res = this.hRM_StatusEmployee_Service.Get(this.Request, model);
            this.commonService.LogTime<StatusEmployeeModel>(this.Request, this.hRM_StatusEmployee_Service._tableName, "Get", res);
            return res;
        }

        [HttpPost("StatusEmployeeDelete")]
        public async Task<ActionResult<StatusMessage<StatusEmployeeModel>>> PositionDelete(StatusEmployeeModel model)
        {
            var res = this.hRM_StatusEmployee_Service.Delete(this.Request, model);
            this.commonService.LogTime<StatusEmployeeModel>(this.Request, this.hRM_StatusEmployee_Service._tableName, "Delete", res);
            return res;
        }

        [HttpPost("StatusEmployeeSearch")]
        public async Task<ActionResult<StatusMessage<List<StatusEmployeeModel>>>> PositionSearch(StatusEmployeeModel model)
        {
            var res = this.hRM_StatusEmployee_Service.Search(this.Request, model);
            this.commonService.LogTime<List<StatusEmployeeModel>>(this.Request, this.hRM_StatusEmployee_Service._tableName, "Search", res);
            return res;
        }

        [HttpPost("StatusEmployeeUpdate")]
        public async Task<ActionResult<StatusMessage<StatusEmployeeModel>>> PositionUpdate(StatusEmployeeModel model)
        {
            var res = this.hRM_StatusEmployee_Service.Update(this.Request, model);
            this.commonService.LogTime<StatusEmployeeModel>(this.Request, this.hRM_StatusEmployee_Service._tableName, "Update", res);
            return res;
        }

        // HRM_TypeEmployee_Service

        [HttpPost("TypeEmployeeInsert")]
        public async Task<ActionResult<StatusMessage<TypeEmployeeModel>>> TypeEmployeeInsert(TypeEmployeeModel model)
        {
            var res = this.hRM_TypeEmployee_Service.Insert(this.Request, model);
            this.commonService.LogTime<TypeEmployeeModel>(this.Request, this.hRM_TypeEmployee_Service._tableName, "Insert", res);
            return res;
        }


        [HttpPost("TypeEmployeeGet")]
        public async Task<ActionResult<StatusMessage<TypeEmployeeModel>>> TypeEmployeeGet(TypeEmployeeModel model)
        {
            var res = this.hRM_TypeEmployee_Service.Get(this.Request, model);
            this.commonService.LogTime<TypeEmployeeModel>(this.Request, this.hRM_TypeEmployee_Service._tableName, "Get", res);
            return res;
        }

        [HttpPost("TypeEmployeeDelete")]
        public async Task<ActionResult<StatusMessage<TypeEmployeeModel>>> TypeEmployeeDelete(TypeEmployeeModel model)
        {
            var res = this.hRM_TypeEmployee_Service.Delete(this.Request, model);
            this.commonService.LogTime<TypeEmployeeModel>(this.Request, this.hRM_TypeEmployee_Service._tableName, "Delete", res);
            return res;
        }

        [HttpPost("TypeEmployeeSearch")]
        public async Task<ActionResult<StatusMessage<List<TypeEmployeeModel>>>> TypeEmployeeSearch(TypeEmployeeModel model)
        {
            var res = this.hRM_TypeEmployee_Service.Search(this.Request, model);
            this.commonService.LogTime<List<TypeEmployeeModel>>(this.Request, this.hRM_TypeEmployee_Service._tableName, "Search", res);
            return res;
        }

        [HttpPost("TypeEmployeeUpdate")]
        public async Task<ActionResult<StatusMessage<TypeEmployeeModel>>> TypeEmployeeUpdate(TypeEmployeeModel model)
        {
            var res = this.hRM_TypeEmployee_Service.Update(this.Request, model);
            this.commonService.LogTime<TypeEmployeeModel>(this.Request, this.hRM_TypeEmployee_Service._tableName, "Update", res);
            return res;
        }

        // HRM_TypeWork_Service

        [HttpPost("TypeWorkInsert")]
        public async Task<ActionResult<StatusMessage<TypeWorkModel>>> TypeWorkInsert(TypeWorkModel model)
        {
            var res = this.hRM_TypeWork_Service.Insert(this.Request, model);
            this.commonService.LogTime<TypeWorkModel>(this.Request, this.hRM_TypeWork_Service._tableName, "Insert", res);
            return res;
        }


        [HttpPost("TypeWorkGet")]
        public async Task<ActionResult<StatusMessage<TypeWorkModel>>> TypeWorkGet(TypeWorkModel model)
        {
            var res = this.hRM_TypeWork_Service.Get(this.Request, model);
            this.commonService.LogTime<TypeWorkModel>(this.Request, this.hRM_TypeWork_Service._tableName, "Get", res);
            return res;
        }

        [HttpPost("TypeWorkDelete")]
        public async Task<ActionResult<StatusMessage<TypeWorkModel>>> TypeWorkDelete(TypeWorkModel model)
        {
            var res = this.hRM_TypeWork_Service.Delete(this.Request, model);
            this.commonService.LogTime<TypeWorkModel>(this.Request, this.hRM_TypeWork_Service._tableName, "Delete", res);
            return res;
        }

        [HttpPost("TypeWorkSearch")]
        public async Task<ActionResult<StatusMessage<List<TypeWorkModel>>>> TypeWorkSearch(TypeWorkModel model)
        {
            var res = this.hRM_TypeWork_Service.Search(this.Request, model);
            this.commonService.LogTime<List<TypeWorkModel>>(this.Request, this.hRM_TypeWork_Service._tableName, "Search", res);
            return res;
        }

        [HttpPost("TypeWorkUpdate")]
        public async Task<ActionResult<StatusMessage<TypeWorkModel>>> TypeWorkUpdate(TypeWorkModel model)
        {
            var res = this.hRM_TypeWork_Service.Update(this.Request, model);
            this.commonService.LogTime<TypeWorkModel>(this.Request, this.hRM_TypeWork_Service._tableName, "Update", res);
            return res;
        }



    }
}
