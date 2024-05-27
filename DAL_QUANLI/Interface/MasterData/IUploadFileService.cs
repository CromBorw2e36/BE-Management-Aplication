using DAL_QUANLI.Models.DataDB;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface.MasterData
{
    public interface IUploadFileService
    {
        public Task<StatusMessage<List<UploadFileModel>>> Insert(HttpRequest httpRequest, UploadFileModel model);
        public Task<StatusMessage<List<UploadFileModel>>> Insert12(HttpRequest httpRequest, List<IFormFile> files, string tableName, string col_name);
        public List<UploadFileModel> Search(HttpRequest httpRequest, UploadFileModel model);
    }
}
