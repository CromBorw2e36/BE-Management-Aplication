using quan_li_app.Models.DataDB.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.CustomModel
{
    public class UserInfoGetListModel: UserInfo
    {
        public string? status { get; set; }
        public DateTime? lock_date { get; set; }
        public DateTime? last_enter { get; set; }
        //public string? email { get; set; }
        public string? type_account { get; set; }
        [NotMapped]
        public string? namePermision { get; set; }
        public string? status_f { get; set; }
        public string? type_account_f { get; set; }

    }
}
