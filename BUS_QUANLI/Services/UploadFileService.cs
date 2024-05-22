using quan_li_app.Helpers.Dictionary;
using quan_li_app.Helpers;
using quan_li_app.Models;
using quan_li_app.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QUANLI.Interface;
using DAL_QUANLI.Models.DataDB;
using Microsoft.EntityFrameworkCore;

namespace BUS_QUANLI.Services
{
    public class UploadFileService : IUploadFileService
    {
        public readonly DataContext dataContext;
        public readonly SystemContext systemContext;
        public readonly CommonHelpers commonHelpers;
        public readonly ViewModelAccount viewModelAccount;
        public readonly TokenHelper tokenHelper;
        public readonly StatusMessageMapper statusMessageMapper;
        public readonly LogTimeDataUpdateService logTimeDataUpdateService;

        public UploadFileService()
        {
            this.dataContext = new DataContext();
            this.systemContext = new SystemContext();
            this.viewModelAccount = new ViewModelAccount();
            this.commonHelpers = new CommonHelpers();
            this.tokenHelper = new TokenHelper();
            this.statusMessageMapper = new StatusMessageMapper();
            this.logTimeDataUpdateService = new LogTimeDataUpdateService();
        }

        public async Task<List<UploadFileModel>> Insert(UploadFileModel model)
        {
            if (model.files == null || !model.files.Any())
            {
                return null;
            }

            List<UploadFileModel> uploadedFiles = new List<UploadFileModel>();

            foreach (var file in model.files)
            {
                if (file.Length > 0)
                {
                    DateTime date = DateTime.UtcNow.AddHours(7);
                    string fileId = commonHelpers.GenerateRowID("UploadFileModel", model.company_code ?? ""); 
                    string extention = Path.GetExtension(file.FileName);
                    string fileName = $"{date:yyyyMMdd-HHmmss}-{fileId}{extention}";
                    string filePath = Path.Combine( "Upload/Files", fileName);

                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var uploadFile = new UploadFileModel
                    {
                        id = fileId,
                        table_name = model.table_name,
                        create_date = date.ToString("yyyy-MM-dd HH:mm:ss"),
                        create_by = model.create_by,
                        file_name = file.FileName,
                        file_type = file.ContentType,
                        file_size = file.Length.ToString(),
                        file_path = fileName,
                        description = model.description,
                        company_code = model.company_code,
                        enabled = model.enabled ?? true
                    };

                    dataContext.UploadFileModels.Add(uploadFile);
                    uploadedFiles.Add(uploadFile);
                }
            }

            await dataContext.SaveChangesAsync();
            return uploadedFiles;
        }

        public List<UploadFileModel> Search(UploadFileModel model)
        {
            throw new NotImplementedException();
        }
    }
}
