using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;

namespace DAL_QUANLI.Interface.MasterData
{
    public interface ICategoryService<T>
    {
        StatusMessage<T> Insert(HttpRequest httpRequest, T model);
        StatusMessage<T> Update(HttpRequest httpRequest, T model);
        StatusMessage<T> Get(HttpRequest httpRequest, T model);
        StatusMessage<List<T>> Search(HttpRequest httpRequest, T model);
        StatusMessage<T> Delete(HttpRequest httpRequest, T model);
    }
}
