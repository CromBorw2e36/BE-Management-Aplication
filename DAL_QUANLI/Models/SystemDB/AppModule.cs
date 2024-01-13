namespace quan_li_app.Models.SystemDB
{
    public class AppModule
    {
        public string? code { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public bool? enabled { get; set; }
        public DateTime dateEnable { get; set; }
    }
}

// Quản lí các source moduler app đang có
// 