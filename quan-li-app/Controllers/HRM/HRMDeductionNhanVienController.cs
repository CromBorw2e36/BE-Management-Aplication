using BUS_QUANLI.Services.HRM;
using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Models.DataDB.QuanLiNhanSu.DanhMuc;
using Microsoft.AspNetCore.Mvc;
using quan_li_app.Models.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quan_li_app.Controllers.HRM
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRMDeductionNhanVienController : ControllerBase
    {
        private readonly CommonService commonService;
        private readonly HRM_DecductionNhanVien_Service hRM_DecductionNhanVien_Service;

        public HRMDeductionNhanVienController()
        {
            this.commonService = new CommonService();
            this.hRM_DecductionNhanVien_Service = new HRM_DecductionNhanVien_Service();
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<StatusMessage<DeductionNhanVienModel>>> Insert(DeductionNhanVienModel model)
        {
            var res = this.hRM_DecductionNhanVien_Service.Insert(this.Request, model);
            this.commonService.LogTime<DeductionNhanVienModel>(this.Request, this.hRM_DecductionNhanVien_Service._tableName, "Insert", res);
            return res;
        }


        [HttpPost("Get")]
        public async Task<ActionResult<StatusMessage<DeductionNhanVienModel>>> Get(DeductionNhanVienModel model)
        {
            var res = this.hRM_DecductionNhanVien_Service.Get(this.Request, model);
            this.commonService.LogTime<DeductionNhanVienModel>(this.Request, this.hRM_DecductionNhanVien_Service._tableName, "Get", res);
            return res;
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<StatusMessage<DeductionNhanVienModel>>> Delete(DeductionNhanVienModel model)
        {
            var res = this.hRM_DecductionNhanVien_Service.Delete(this.Request, model);
            this.commonService.LogTime<DeductionNhanVienModel>(this.Request, this.hRM_DecductionNhanVien_Service._tableName, "Delete", res);
            return res;
        }

        [HttpPost("Search")]
        public async Task<ActionResult<StatusMessage<List<DeductionNhanVienModel>>>> Search(DeductionNhanVienModel model)
        {
            var res = this.hRM_DecductionNhanVien_Service.Search(this.Request, model);
            this.commonService.LogTime<List<DeductionNhanVienModel>>(this.Request, this.hRM_DecductionNhanVien_Service._tableName, "Search", res);
            return res;
        }

    }
}
