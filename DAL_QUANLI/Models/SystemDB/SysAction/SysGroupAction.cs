namespace DAL_QUANLI.Models.SystemDB.SysAction
{
    public class SysGroupAction
    {
        public string? code { get; set; } // code of sysGroupAction
        public string? codeAction { get; set; } // code of sysAction
        public string? orderNo { get; set; } // Thứ tứ vị trí
        public string? description { get; set; } // description of sysGroupAction
        public bool? isClocked { get; set; } // Khóa action này lại

    }
}
