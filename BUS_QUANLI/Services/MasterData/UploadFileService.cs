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
using System.Net.Http.Headers;
using System.Web.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using DAL_QUANLI.Models.CustomModel;

namespace BUS_QUANLI.Services.MasterData
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
        public readonly string _tableName = "UploadFile";

        private readonly string[] AllowedDocumentTypes = { "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
        private readonly string[] AllowedOrderTypes = { "text/plain" }; // Assuming orders are text files
        private readonly string[] AllowedImageTypes = { "image/jpeg", "image/png", "image/gif" };
        private readonly string[] AllowedVideoTypes = { "video/mp4", "video/mpeg", "video/quicktime" };



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

        private string FileType(string contentType)
        {
            if (AllowedDocumentTypes.Contains(contentType))
            {
                return "Document";
            }
            else if (AllowedOrderTypes.Contains(contentType))
            {
                return "Order";
            }
            else if (AllowedImageTypes.Contains(contentType))
            {
                return "Image";
            }
            else if (AllowedVideoTypes.Contains(contentType))
            {
                return "Video";
            }
            else
            {
                return "Order"; // Unknown file type
            }
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
                            create_date = DateTime.Now,
                            create_by = this.tokenHelper.GetUsername(httpRequest),
                            file_name = file.FileName,
                            file_type = file.ContentType,
                            file_size = file.Length,
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
                return new StatusMessage<List<UploadFileModel>>(0, this.GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), uploadedFiles);
            }
            catch
            {
                return new StatusMessage<List<UploadFileModel>>(1, this.GetMessageDescription(EnumQuanLi.InsertError, httpRequest), model);
            }
        }

        public async Task<StatusMessage<List<UploadFileModel>>> Insert12(HttpRequest httpRequest, List<IFormFile> files, string tableName, string col_name)
        {
            try
            {
                List<UploadFileModel> uploadedFiles = new List<UploadFileModel>();

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        DateTime date = DateTime.UtcNow.AddHours(7);
                        string fileId = commonHelpers.GenerateRowID(this._tableName);
                        string extension = Path.GetExtension(file.FileName);
                        string fileName = $"{date:yyyy-MM-dd_HH-mm-ss}_{fileId}{extension}";
                        string folderNameFile = this.FileType(file.ContentType);
                        string filePath_f = Path.Combine("Upload", folderNameFile, tableName, col_name);
                        string filePath = Path.Combine(filePath_f, fileName);

                        // Ensure the directory exists
                        if (!Directory.Exists(filePath_f))
                        {
                            Directory.CreateDirectory(filePath_f);
                        }

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        var uploadFile = new UploadFileModel
                        {
                            id = fileId,
                            table_name = tableName,
                            create_date = DateTime.Now,
                            create_by = tokenHelper.GetUsername(httpRequest) ?? "UNKNOWN",
                            file_name = file.FileName,
                            file_type = file.ContentType,
                            file_size = file.Length,
                            file_path = $"{filePath_f}/{fileName}",  // Store the full file path here
                            description = "your_description",
                            company_code = "your_company_code",
                            enabled = true,
                            col_name = col_name
                        };

                        dataContext.UploadFileModels.Add(uploadFile);
                        this.dataContext.SaveChanges();
                        uploadedFiles.Add(uploadFile);
                    }
                }
                return new StatusMessage<List<UploadFileModel>>(0, "Insert success message", uploadedFiles);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine(ex);
                return new StatusMessage<List<UploadFileModel>>(1, "Insert error message", null);
            }
        }




        public List<UploadFileModel> Search(HttpRequest httpRequest, UploadFileModel model)
        {
            throw new NotImplementedException();
        }

        public FileStreamResult GetFile(string filePath)
        {
            var res = this.dataContext.UploadFileModels.Where(x => x.id == filePath).FirstOrDefault();
            if (res == null)
            {
                return null;
            }

            var path = Path.Combine(res.file_path); // Adjust the path as needed
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            var mimeType = "application/octet-stream"; // Adjust the MIME type if necessary
            return new FileStreamResult(stream, mimeType)
            {
                FileDownloadName = Path.GetFileName(filePath)
            };
        }

        private string GetMimeType(string filePath)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;

        }


    }
}
