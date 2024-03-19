using DAL_QUANLI.Models.CustomModel;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.DataDB.UserData;
using quan_li_app.ViewModels.Data;

namespace BUS_QUANLI.Services
{
    public class UserInformationClient : StatusMessageMapper
    {
        private readonly DataContext _dataContext;
        private readonly CommonHelpers commonHelpers;
        private readonly ViewModelAccount viewModelAccount;
        private readonly TokenHelper tokenHelper;

        public UserInformationClient(DataContext pDataContext)
        {
            this._dataContext = pDataContext;
            this.viewModelAccount = new ViewModelAccount(pDataContext);
            this.commonHelpers = new CommonHelpers();
            this.tokenHelper = new TokenHelper();
        }


        public async Task<UserInformationClientGetUser> getUserInformation(string userId)
        {
            Account account = _dataContext.Accounts.FirstOrDefault(x => x.account.Equals(userId));
            UserInfo userInfo = _dataContext.UserInfomation.FirstOrDefault(x => x.id.Equals(userId));
            if (account != null && userInfo != null)
            {
                Company company = _dataContext.Companies.FirstOrDefault(x => x.code == userInfo.codeCompany);
                List<TOKEN> tokens = _dataContext.Tokens.Where(x => x.username == userId).OrderByDescending(x => x.date).Take(20).ToList();

                UserInformationClientGetUser obj = new UserInformationClientGetUser
                {
                    email = account.email,
                    id = userInfo.id,
                    name = userInfo.name,
                    dateOfBirth = userInfo.dateOfBirth,
                    address = userInfo.address,
                    phoneNumber = userInfo.phoneNumber,
                    gender = userInfo.gender,
                    nationality = userInfo.nationality,
                    ethnicity = userInfo.ethnicity,
                    interests = userInfo.interests,
                    maritalStatus = userInfo.maritalStatus,
                    modifyDate = userInfo.modifyDate,
                    BHXH = userInfo.BHXH,
                    CCCD = userInfo.CCCD,
                    codeCompany = userInfo.codeCompany,
                    avatar = userInfo.avatar,
                    avatar16 = userInfo.avatar16,
                    avatar32 = userInfo.avatar32,
                    avatar64 = userInfo.avatar64,
                    nameDepartment = "",
                    nameBrach = "",
                    nameCompany = company != null ? company.name : "",
                    Tokens = tokens
                };
                return obj;
            }
            return null;
        }

    }
}
