namespace quan_li_app.Models.SystemDB
{
    public class SysMenu
    {
        public string? menuid { get; set; }
        public string? url { get; set; }
        public string? name { get; set; }
        public string? nameVN { get; set; }
        public string? icon { get; set; }
        public bool? active { get; set; }
        public bool? isParent { get; set; }
        public string? menuIDParent { get; set; }
        public bool? defaultActive { get; set; }
        public string? moduleApp { get; set; }
        // Thuộc dự án: Quản lí nhân sự, quản lí công việc, quản lí bán hàng
        public string? action1 { get; set; }
        public string? action2 { get; set; }
        public string? action3 { get; set; }
        public string? action4 { get; set; }
        public string? action5 { get; set; }
        public string? action6 { get; set; }
        public string? action7 { get; set; }


        //public SysMenu()
        //{
        //    menuid = Guid.NewGuid().ToString();
        //    name = "";
        //    active = true;
        //    isParent = false;
        //    menuIDParent = null;
        //    moduleApp = "";
        //}

    }
}
