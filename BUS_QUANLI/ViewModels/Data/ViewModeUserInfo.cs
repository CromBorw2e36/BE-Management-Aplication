using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.DataDB.UserData;

namespace quan_li_app.ViewModels.Data
{
    public class ViewModeUserInfo : BaseMapper
    {
        private readonly DataContext _contextData;
        private readonly SystemContext _contextSystem;
        public ViewModeUserInfo(DataContext dbcontext, SystemContext systemContext)
        {
            this._contextData = dbcontext;
            this._contextSystem = systemContext;
        }


        public async Task<bool> NewUserInfo(Account account)
        {
            UserInfo newUser = new UserInfo
            {
                id = account.account,
                name = GetMessageDescription(EnumQuanLi.NEWUSER),
                dateOfBirth = DateTime.Now,
                address = "",
                phoneNumber = "",
                gender = "",
                nationality = "",// quốc tịch
                ethnicity = "",//  dân tộc
                interests = "",// sở thích
                maritalStatus = "", //  tình trạng hôn nhân
                modifyDate = DateTime.Now,//  tình trạng hôn nhân
                BHXH = "",// sở thích
                CCCD = "",// sở thích
                codeCompany = account.companyCode// công ty
            };

            try
            {
                _contextData.UserInfomation.Add(newUser);
                await _contextData.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                return false;
            }

        }
    }
}
