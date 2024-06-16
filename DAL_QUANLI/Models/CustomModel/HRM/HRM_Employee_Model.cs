using DAL_QUANLI.Models.DataDB.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLI.Models.CustomModel.HRM
{
    public class HRM_Employee_Model: EmployeeModel
    {
        public string? position_name { get; set; }
        public string? department_name { get; set; }
        public string? type_employee_name { get; set; } 
        public string? type_work_name { get; set; }
    }
}
