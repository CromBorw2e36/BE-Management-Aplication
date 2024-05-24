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
    public interface INationalLanguageService
    {
        StatusMessage<List<National>> Search(HttpRequest httpRequest, National model);
        StatusMessage<National> Insert(HttpRequest httpRequest, National model);
        StatusMessage<National> Update(HttpRequest httpRequest, National model);
        StatusMessage<National> Delete(HttpRequest httpRequest, National model);
    }
}
