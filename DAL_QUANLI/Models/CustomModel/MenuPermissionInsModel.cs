using quan_li_app.Models.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.CustomModel
{
    public class MenuPermissionInsModel
    {
        public Account? account {  get; set; }
        public List<MenuPermissions>? list_permission { get; set; }
    }
}
