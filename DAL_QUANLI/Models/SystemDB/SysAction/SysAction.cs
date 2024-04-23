using quan_li_app.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_QUANLI.Models.SystemDB.SysAction
{
    public class SysAction
    {
        public string? code { get; set; }
        public string? nameVn { get; set; }
        public string? nameOther { get; set; }
        public string? icon { get; set; }
        public string? color { get; set; }
        public string? backgroundColor { get; set; }
        public bool? isDisable { get; set; } // chỉ khả dùng khi selected
        public string? description { get; set; }
        public string? url_1 { get; set; } // Đường dẫn URL khi click
        public string? url_2 { get; set; } // Đường dẫn URL khi click bổ sung 
        public string? url_3 { get; set; } // Đường dẫn URL khi click bổ sung
        public string? url_4 { get; set; } // Đường dẫn URL khi click bổ sung
        [NotMapped]
        public bool? isClocked { get; set; }
        [NotMapped]
        public string? codeGroup { get; set; }
        [NotMapped]
        public int? orderNo { get; set; }

        public static implicit operator SysAction(SysStatus v)
        {
            throw new NotImplementedException();
        }
    }
}
