using DAL_QUANLI.Models.CustomModel;
using quan_li_app.Models.DataDB.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.DataDB.User
{
    public class EmployeeModel : UserInfo
    {
        public string? department_id {  get; set; }
        public string? type_employee_id { get; set; }
        public string? position_id { get; set; }
        public string? type_work_id { get; set; }
        public bool? is_delete { get; set; }
        public DateTime? create_at { get; set; }
        public DateTime? update_at { get;set; }
        public DateTime? delete_at { get; set; }
        public string? create_by { get; set; }
        public string? update_by { get; set; }
        public string? delete_by { get;set; }
    }
}
