using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;

namespace DAL_QUANLI.Interface
{
    public interface ICategory<T>
    {
        Task<StatusMessage<T>> Insert(T pObject, HttpRequest httpRequest);
        Task<StatusMessage<List<T>>> Insert2(List<T> pObject, HttpRequest httpRequest); //  Insert nhiều
        Task<StatusMessage<T>> Update(T pObject, HttpRequest httpRequest);
        Task<StatusMessage<List<T>>> Update2(List<T> pObject, HttpRequest httpRequest);
        Task<StatusMessage<T>> Get(T pObject, HttpRequest httpRequest);
        Task<StatusMessage<List<T>>> Filter(T pObject, HttpRequest httpRequest);
        Task<StatusMessage<dynamic>> Delete(List<T> pObject, HttpRequest httpRequest);
        Task<StatusMessage<dynamic>> Delete(List<T> pObject, HttpRequest httpRequest, dynamic pObject2); //  Trường hợp phát sinh khác
    }
}
