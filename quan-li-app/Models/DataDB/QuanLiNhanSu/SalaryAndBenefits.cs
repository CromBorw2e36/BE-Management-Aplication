namespace quan_li_app.Models.DataDB.QuanLiNhanSu
{
    public class SalaryAndBenefits
    {
        public string? id { get; set; }
        public DateTime? date { get; set; }
        public string? IdUserInfo { get; set; }
        public string? modyfiBy { get; set; } // Người cập nhật
        public decimal? salary { get; set; }
        public string? benefits { get; set; }
        public string? wagesAndPerks { get; set; }
        public decimal? compensationPackageAmount { get; set; }
        public string? compensationPackage { get; set; }
        public decimal? compensationPackageAmount1 { get; set; }
        public string? compensationPackage1 { get; set; }
        public decimal? compensationPackageAmount2 { get; set; }
        public string? compensationPackage2 { get; set; }
        public decimal? compensationPackageAmount3 { get; set; }
        public string? compensationPackage3 { get; set; }
        public string? insuranceCoverage { get; set; }
        public decimal? allowancesAndAidsAmount { get; set; }
        public string? allowancesAndAids { get; set; }
        public decimal? allowancesAndAidsAmount1 { get; set; }
        public string? allowancesAndAids1 { get; set; }
        public decimal? allowancesAndAidsAmount2 { get; set; }
        public string? allowancesAndAids2 { get; set; }
        public decimal? allowancesAndAidsAmount3 { get; set; }
        public string? allowancesAndAids3 { get; set; }
        //public string? remunerationAndIncentives { get; set; }  //  lương thưởng cần làm riêng ra 
    }
}

//salaryAndBenefits: Lương và các khoản phúc lợi được cung cấp cho nhân viên trong vị trí công việc, bao gồm mức lương cơ bản và các lợi ích khác như bảo hiểm, phúc lợi, hay các khoản trợ cấp.

//wagesAndPerks: Lương và các tiện ích/đặc quyền khác được cung cấp cho nhân viên, thường bao gồm mức lương cơ bản và các phúc lợi hay ưu đãi khác.

//compensationPackage: Gói bồi thường bao gồm tất cả các phần của lương và các khoản thù lao, như bảo hiểm, trợ cấp, thưởng, hay các khoản phúc lợi khác mà nhân viên có được từ công ty.

//insuranceCoverage: Phạm vi bảo hiểm mà công ty cung cấp cho nhân viên, bao gồm các loại bảo hiểm như bảo hiểm y tế, bảo hiểm tai nạn, bảo hiểm sức khỏe, v.v.

//allowancesAndAids: Các khoản trợ cấp và hỗ trợ khác mà nhân viên nhận được từ công ty, bao gồm các khoản trợ cấp cho đi lại, ăn trưa, hoặc các chương trình hỗ trợ khác.

//remunerationAndIncentives: Tiền lương và các động lực khác mà công ty cung cấp cho nhân viên, có thể bao gồm cả tiền thưởng, phúc lợi không tiền mặt, hay các ưu đãi khác nhằm kích thích hiệu suất làm việc và động viên nhân viên.