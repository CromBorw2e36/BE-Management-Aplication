namespace DAL_QUANLI.Models.DataDB
{
    public class DocumentManagement
    {
        public string? code { get; set; }
        public string? module { get; set; }
        public string? tableName { get; set; }
        public int? lenCode { get; set; }
        public string? primaryKeyTable { get; set; }
        public bool? isCompanyCode { get; set; }
        public bool? isClose { get; set; }
        public string? description { get; set; }
        public string? codeLogTime { get; set; }

    }
}
