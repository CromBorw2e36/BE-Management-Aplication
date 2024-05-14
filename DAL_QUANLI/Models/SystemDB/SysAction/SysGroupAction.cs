using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_QUANLI.Models.SystemDB.SysAction
{
    public class SysGroupAction
    {
        public string? code { get; set; } // code of sysGroupAction // duoc phep trung vơi nhau
        public string? codeAction { get; set; } // code of sysAction
        public int? orderNo { get; set; } // Thứ tứ vị trí
        public string? description { get; set; } // description of sysGroupAction
        public bool? isClocked { get; set; } // Khóa action này lại
        public bool? isDropDown { get; set; } // Là Action drop down
        [NotMapped]
        public List<SysAction>? listChildAction { get; set; } // Danh sách action khi get lên
    }
}
