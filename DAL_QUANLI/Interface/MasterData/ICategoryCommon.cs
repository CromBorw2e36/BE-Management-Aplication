using DAL_QUANLI.Models.DataDB;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;

namespace DAL_QUANLI.Interface.MasterData
{
    public interface ICategoryCommon
    {
        StatusMessage<CategoryCommonModel> Insert(HttpRequest httpRequest, CategoryCommonModel model);
        StatusMessage<List<CategoryCommonModel>> Search(HttpRequest httpRequest, CategoryCommonModel model);
        StatusMessage<CategoryCommonModel> Update(HttpRequest httpRequest, CategoryCommonModel model);
        StatusMessage<CategoryCommonModel> Delete(HttpRequest httpRequest, CategoryCommonModel model);
        public void LogTime<T>(HttpRequest httpRequest, string action, StatusMessage<T> message);

    }
}
