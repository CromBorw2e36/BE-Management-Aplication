using quan_li_app.Helpers.Dictionary;
using quan_li_app.Helpers;
using quan_li_app.Models;
using quan_li_app.ViewModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QUANLI.Models.DataDB;
using Microsoft.EntityFrameworkCore;
using DAL_QUANLI.Interface.MasterData;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;

namespace BUS_QUANLI.Services.MasterData
{
    public class UploadFileService :  IUploadFileService
    {
        public readonly DataContext dataContext;
        public readonly SystemContext systemContext;
        public readonly CommonHelpers commonHelpers;
        public readonly ViewModelAccount viewModelAccount;
        public readonly TokenHelper tokenHelper;
        public readonly StatusMessageMapper statusMessageMapper;
        public readonly LogTimeDataUpdateService logTimeDataUpdateService;
        public readonly string _tableName = "UploadFile";



        public UploadFileService()
        {
            dataContext = new DataContext();
            systemContext = new SystemContext();
            viewModelAccount = new ViewModelAccount();
            commonHelpers = new CommonHelpers();
            tokenHelper = new TokenHelper();
            statusMessageMapper = new StatusMessageMapper();
            logTimeDataUpdateService = new LogTimeDataUpdateService();
        }

        public string GetMessageDescription(EnumQuanLi param, HttpRequest httpRequest)
        {
            return statusMessageMapper.GetMessageDescription(param, httpRequest);
        }

        public async Task<StatusMessage<List<UploadFileModel>>> Insert(HttpRequest httpRequest, UploadFileModel model)
        {
            try
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
                        string fileId = commonHelpers.GenerateRowID(this._tableName);
                        string extention = Path.GetExtension(file.FileName);
                        string fileName = $"{date:yyyyMMdd-HHmmss}-{fileId}{extention}";
                        string filePath = Path.Combine("Upload/Files", fileName);

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
                            create_by = this.tokenHelper.GetUsername(httpRequest),
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
                return new StatusMessage<List<UploadFileModel>>(0, this.GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest) , uploadedFiles);
            }
            catch
            {
                return new StatusMessage<List<UploadFileModel>>(1, this.GetMessageDescription(EnumQuanLi.InsertError, httpRequest) ,model);
            }
        }

        public List<UploadFileModel> Search(HttpRequest httpRequest, UploadFileModel model)
        {
            throw new NotImplementedException();
        }
    }
}
