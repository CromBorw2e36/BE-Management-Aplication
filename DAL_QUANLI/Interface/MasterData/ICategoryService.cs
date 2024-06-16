using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;

namespace DAL_QUANLI.Interface.MasterData
{
    public interface ICategoryService<T>
    {
        Task<StatusMessage<T>> Insert(HttpRequest httpRequest, T model);
        Task<StatusMessage<T>> Update(HttpRequest httpRequest, T model);
        Task<StatusMessage<T>> Get(HttpRequest httpRequest, T modelt);
        Task<StatusMessage<List<T>>> Search(HttpRequest httpRequest, T model);
        Task<StatusMessage<T>> Delete(HttpRequest httpRequest, T model);
    }
}
