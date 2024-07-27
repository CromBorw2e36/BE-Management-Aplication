using BUS_QUANLI.Services.HRM;
using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Models.DataDB.QuanLiNhanSu;
using DAL_QUANLI.Models.DataDB.QuanLiNhanSu.DanhMuc;
using Microsoft.AspNetCore.Mvc;
using quan_li_app.Models.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quan_li_app.Controllers.HRM
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRMLaborContactController : ControllerBase
    {
        private readonly CommonService commonService;
        private readonly HRM_LaborContact_Service hRM_LaborContact_Service;

        public HRMLaborContactController()
        {
            this.commonService = new CommonService();
            this.hRM_LaborContact_Service = new HRM_LaborContact_Service();
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<StatusMessage<LaborContactModel>>> Insert(LaborContactModel model)
        {
            var res = this.hRM_LaborContact_Service.Insert(this.Request, model);
            this.commonService.LogTime<LaborContactModel>(this.Request, this.hRM_LaborContact_Service._tableName, "Insert", res);
            return res;
        }

        [HttpPost("Get")]
        public async Task<ActionResult<StatusMessage<LaborContactModel>>> Get(LaborContactModel model)
        {
            var res = this.hRM_LaborContact_Service.Get(this.Request, model);
            this.commonService.LogTime<LaborContactModel>(this.Request, this.hRM_LaborContact_Service._tableName, "Get", res);
            return res;
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<StatusMessage<LaborContactModel>>> Delete(LaborContactModel model)
        {
            var res = this.hRM_LaborContact_Service.Delete(this.Request, model);
            this.commonService.LogTime<LaborContactModel>(this.Request, this.hRM_LaborContact_Service._tableName, "Delete", res);
            return res;
        }

        [HttpPost("Search")]
        public async Task<ActionResult<StatusMessage<List<LaborContactModel>>>> Search(LaborContactModel model)
        {
            var res = this.hRM_LaborContact_Service.Search(this.Request, model);
            this.commonService.LogTime<List<LaborContactModel>>(this.Request, this.hRM_LaborContact_Service._tableName, "Search", res);
            return res;
        }

    }
}
