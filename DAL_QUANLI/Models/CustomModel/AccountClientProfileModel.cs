using quan_li_app.Models.DataDB;
using quan_li_app.Models.DataDB.UserData;

namespace DAL_QUANLI.Models.CustomModel
{
    public class AccountClientProfileModel
    {
        public Account? account { get; set; }
        public UserInfo? userInfo { get; set; }
        public TOKEN? token { get; set; }
        public AccountClientProfileModel() { }
    }
}
