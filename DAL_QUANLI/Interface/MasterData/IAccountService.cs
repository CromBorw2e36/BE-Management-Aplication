using DAL_QUANLI.Models.CustomModel;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.DataDB.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Interface.MasterData
{
    public interface IAccountService
    {
        public StatusMessage<AccountClientProfileModel> Update(HttpRequest httpRequest, AccountClientProfileModel account);
        public StatusMessage<AccountClientProfileModel> Search(HttpRequest httpRequest, Account model);
        public StatusMessage<List<UserInfoGetListModel>> GetListUser(HttpRequest httpRequest, Account model);
        public StatusMessage<List<UserInfoGetListModel>> GetListUserRegister(HttpRequest httpRequest, Account model);
        public StatusMessage<Account> Delete(HttpRequest httpRequest, Account model);
        public Task<StatusMessage<dynamic>> AccountClientIns(AccountClientProfileModel acc, string userName_create);
        public StatusMessage<dynamic> Lock(HttpRequest httpRequest, Account model);
        public StatusMessage<dynamic> Approval(HttpRequest httpRequest, Account model);
        public StatusMessage<dynamic> ChangePassword(HttpRequest httpRequest, Account model);



    }
}
