using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface.MasterData
{
    public interface ICompanyService
    {
        public StatusMessage<Company> Insert(HttpRequest httpRequest, Company model);
        public StatusMessage<Company> Update(HttpRequest httpRequest, Company model);
        public StatusMessage<Company> Delete(HttpRequest httpRequest, Company model);   
        public StatusMessage<List<Company>> Search(HttpRequest httpRequest, Company model);
        public StatusMessage<Company> Get(HttpRequest httpRequest, Company model);
        public StatusMessage<Company> InsertCompanyChild(HttpRequest httpRequest, Company model);
    }
}
