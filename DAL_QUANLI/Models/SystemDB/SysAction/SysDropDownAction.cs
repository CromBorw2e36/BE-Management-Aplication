namespace DAL_QUANLI.Models.SystemDB.SysAction
{
    public class SysDropDownAction
    {
        public string? code { get; set; } // code for SysDropDownAction
        public string? codeAction { get; set; } // Code of sysAction
        public int? orderNo { get; set; } // Thứ tứ vị trí
        public string? description { get; set; } // description of SysDropDownAction
        public bool? isClocked { get; set; } // Khóa action này lại

    }
}
