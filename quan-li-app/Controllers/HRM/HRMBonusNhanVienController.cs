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
    public class HRMBonusNhanVienController : ControllerBase
    {
        private readonly CommonService commonService;
        private readonly HRM_PhuCapNhanVien_Service hRM_PhuCapNhanVien_Service;

        public HRMBonusNhanVienController()
        {
            this.commonService = new CommonService();
            this.hRM_PhuCapNhanVien_Service = new HRM_PhuCapNhanVien_Service();
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<StatusMessage<PhuCapNhanvienModel>>> Insert(PhuCapNhanvienModel model)
        {
            var res = this.hRM_PhuCapNhanVien_Service.Insert(this.Request, model);
            this.commonService.LogTime<PhuCapNhanvienModel>(this.Request, this.hRM_PhuCapNhanVien_Service._tableName, "Insert", res);
            return res;
        }


        [HttpPost("Get")]
        public async Task<ActionResult<StatusMessage<PhuCapNhanvienModel>>> Get(PhuCapNhanvienModel model)
        {
            var res = this.hRM_PhuCapNhanVien_Service.Get(this.Request, model);
            this.commonService.LogTime<PhuCapNhanvienModel>(this.Request, this.hRM_PhuCapNhanVien_Service._tableName, "Get", res);
            return res;
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<StatusMessage<PhuCapNhanvienModel>>> Delete(PhuCapNhanvienModel model)
        {
            var res = this.hRM_PhuCapNhanVien_Service.Delete(this.Request, model);
            this.commonService.LogTime<PhuCapNhanvienModel>(this.Request, this.hRM_PhuCapNhanVien_Service._tableName, "Delete", res);
            return res;
        }

        [HttpPost("Search")]
        public async Task<ActionResult<StatusMessage<List<PhuCapNhanvienModel>>>> Search(PhuCapNhanvienModel model)
        {
            var res = this.hRM_PhuCapNhanVien_Service.Search(this.Request, model);
            this.commonService.LogTime<List<PhuCapNhanvienModel>>(this.Request, this.hRM_PhuCapNhanVien_Service._tableName, "Search", res);
            return res;
        }

    }
}
