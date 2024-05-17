using DAL_QUANLI.Interface;
using DAL_QUANLI.Models.DataDB;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QUANLI.Services
{
    public class CategoryCommonService : rootCommonService, ICategoryCommon
    {
        public StatusMessage<CategoryCommonModel> Delete(HttpRequest httpRequest, CategoryCommonModel model)
        {
            try
            {
                if (model.id != null || model?.id?.Length > 0)
                {
                    var result = dataContext.CategoryCommonModels.Where(x => x.id == model.id).FirstOrDefault();
                    if (result != null)
                    {
                        dataContext.CategoryCommonModels.Remove(result);
                        dataContext.SaveChanges();
                        return new StatusMessage<CategoryCommonModel>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), model);
                    }
                    else
                    {
                        return new StatusMessage<CategoryCommonModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                    }
                }
                else if (model?.group_id != null || model?.group_id?.Length > 0)
                {
                    var result = dataContext.CategoryCommonModels.Where(x => x.group_id == model.group_id).ToList();
                    dataContext.CategoryCommonModels.RemoveRange(result);
                    dataContext.SaveChanges();
                    return new StatusMessage<CategoryCommonModel>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), model);
                }
                else
                {
                    return new StatusMessage<CategoryCommonModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }


            }
            catch
            {
                return new StatusMessage<CategoryCommonModel>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest));
            }
        }

        public StatusMessage<CategoryCommonModel> Insert(HttpRequest httpRequest, CategoryCommonModel model)
        {

            try
            {
                if (model.group_id == null || model.group_id.Length == 0)
                {
                    return new StatusMessage<CategoryCommonModel>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest));
                }

                for (int i = 0; i < model.items.Count(); i++)
                {
                    model.items[i].id = commonHelpers.GenerateRowID("CategoryCommon", model.company_code ?? "");
                    model.items[i].create_date = DateTime.Now;
                    model.items[i].create_by = tokenHelper.GetUsername(httpRequest);
                    model.items[i].update_date = DateTime.Now;
                    model.items[i].update_by = tokenHelper.GetUsername(httpRequest);
                    model.items[i].group_id = model.group_id;

                    dataContext.Add(model.items[i]);
                }

                dataContext.SaveChanges();

                return new StatusMessage<CategoryCommonModel>(0, GetMessageDescription(EnumQuanLi.InsertSuccess, httpRequest), model);
            }
            catch
            {
                return new StatusMessage<CategoryCommonModel>(1, GetMessageDescription(EnumQuanLi.InsertError, httpRequest));
            }
        }

        public StatusMessage<List<CategoryCommonModel>> Search(HttpRequest httpRequest, CategoryCommonModel model)
        {
            try
            {
                if (model.group_id == null || model.group_id.Length == 0)
                {
                    var result = dataContext.CategoryCommonModels.ToList();
                    return new StatusMessage<List<CategoryCommonModel>>(0, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), result);
                }
                else
                {
                    // Search with condition is group_id
                    var result = dataContext.CategoryCommonModels.Where(x => x.group_id == model.group_id).ToList();
                    model.items = result;

                    List<CategoryCommonModel> list = new List<CategoryCommonModel>();
                    list.Add(model);

                    return new StatusMessage<List<CategoryCommonModel>>(0, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), list);
                }
            }
            catch
            {
                return new StatusMessage<List<CategoryCommonModel>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
            }
        }

        public StatusMessage<CategoryCommonModel> Update(HttpRequest httpRequest, CategoryCommonModel model)
        {
            try
            {
                if (model.group_id == null || model.group_id.Length == 0)
                {
                    return new StatusMessage<CategoryCommonModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }

                var result = dataContext.CategoryCommonModels.Where(x => x.group_id == model.group_id).ToList();
                dataContext.CategoryCommonModels.RemoveRange(result);

                if (model.items != null)
                {
                    for (int i = 0; i < model.items.Count(); i++)
                    {
                        if (model.items[i].id == null || model.items[i]?.id?.Length == 0) // Insert new item
                        {
                            model.items[i].id = commonHelpers.GenerateRowID("CategoryCommon", model.company_code ?? "");
                            model.items[i].create_date = DateTime.Now;
                            model.items[i].create_by = tokenHelper.GetUsername(httpRequest);
                        }

                        model.items[i].update_date = DateTime.Now;
                        model.items[i].update_by = tokenHelper.GetUsername(httpRequest);
                        model.items[i].group_id = model.group_id;

                        dataContext.Add(model.items[i]);
                    }
                }

                dataContext.SaveChanges();

                return new StatusMessage<CategoryCommonModel>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), model);
            }
            catch
            {
                return new StatusMessage<CategoryCommonModel>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest));
            }
        }
    }
}
