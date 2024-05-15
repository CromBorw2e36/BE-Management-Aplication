using DAL_QUANLI.Models.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface
{
    public interface IUploadFile
    {
        public Task<List<UploadFileModel>> Insert(UploadFileModel model);
        public List<UploadFileModel> Search (UploadFileModel model);
    }
}
