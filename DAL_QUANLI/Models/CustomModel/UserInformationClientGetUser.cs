using quan_li_app.Models.DataDB;
using quan_li_app.Models.DataDB.UserData;

namespace DAL_QUANLI.Models.CustomModel
{
    public class UserInformationClientGetUser : UserInfo
    {
        public string? nameCompany { get; set; }
        public string? email { get; set; }
        public string? nameDepartment { get; set; }
        public string? nameBrach { get; set; }
        public string? codeDepartment { get; set; }
        public string? codeName { get; set; }
        public List<TOKEN> Tokens { get; set; }
    }
}
