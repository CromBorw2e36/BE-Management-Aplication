namespace quan_li_app.Models.DataDB.QuanLiNhanSu
{


    //Lịch sử làm việc của một nhân viên thường bao gồm các thông tin sau:

    //1. * *Công ty và vị trí công việc:**Tên các công ty mà nhân viên đã làm việc trước đó và vị trí mà họ đã đảm nhiệm.

    //2. **Thời gian làm việc:**Thời gian bắt đầu và kết thúc làm việc tại từng công ty hoặc vị trí công việc cụ thể.

    //3. **Mô tả công việc:**Các nhiệm vụ và trách nhiệm đã được giao trong quá trình làm việc tại các công ty trước.

    //4. **Thành tựu và kỹ năng:**Các thành tựu đạt được trong quá trình làm việc, như giải thưởng, dự án quan trọng hoặc các kỹ năng đặc biệt đã phát triển.

    //5. **Lý do thay đổi công việc:**Nguyên nhân chuyển công ty hoặc thay đổi vị trí công việc, có thể bao gồm việc tìm kiếm thách thức mới, phát triển sự nghiệp, vấn đề cá nhân, v.v.

    //Thông tin này giúp tạo ra một cái nhìn tổng quan về quá trình học hỏi và phát triển của nhân viên qua thời gian làm việc của họ.
    public class WorkHistory
    {

        public string? id { get; set; }
        public DateTime? date { get; set; }
        public string? IdUserInfo { get; set; }
        public string? modyfiBy { get; set; } // Người cập nhật
        public string? companyAndPosition { get; set; }
        public DateTime? workHistoryStart { get; set; }
        public DateTime? workHistoryEnd { get; set; }
        public string? timeWorked { get; set; }
        public string? jobdeScription { get; set; }
        public string? achievementSkills { get; set; }
        public string? reasonForChange { get; set; }


    }
}


