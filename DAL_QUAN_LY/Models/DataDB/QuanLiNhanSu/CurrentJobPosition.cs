namespace quan_li_app.Models.DataDB.QuanLiNhanSu
{
    public class CurrentJobPosition
    {
        public string? id { get; set; }
        public DateTime? date { get; set; }
        public string? IdUserInfo { get; set; }
        public string? modyfiBy { get; set; } // Người cập nhật
        public string? jobDescription { get; set; }
        public string? departmentOrTeam { get; set; }
        public string? positionAndLevel { get; set; }
        public string? workSchedule { get; set; }
        //public string? salaryAndBenefits { get; set; }
        public string? currentProjects { get; set; }
        public string? goalsAndDevelopment { get; set; }
    }
}


//Thông tin về vị trí công việc hiện tại của một nhân viên thường bao gồm các yếu tố sau:

//1. * *Mô tả công việc:**Thông tin chi tiết về nhiệm vụ và trách nhiệm mà người đó đảm nhận trong vị trí công việc hiện tại.

//2. **Bộ phận hoặc nhóm làm việc:**Thông tin về bộ phận, nhóm hoặc đội ngũ mà họ thuộc về và làm việc cùng.

//3. **Chức vụ và cấp bậc:**Vị trí cụ thể và cấp bậc công việc của họ trong tổ chức.

//4. **Lịch trình làm việc:**Thời gian làm việc cụ thể, có thể bao gồm giờ làm việc, ca làm việc, hoặc thời gian linh hoạt.

//5. **Mức lương và phúc lợi:**Thông tin về mức lương, các khoản phụ cấp, chế độ bảo hiểm, và các phúc lợi khác liên quan đến vị trí công việc.

//6. **Các dự án hoặc công việc đang thực hiện:**Thông tin về các dự án hoặc công việc cụ thể mà họ đang thực hiện trong thời gian gần đây.

//7. **Mục tiêu và kế hoạch phát triển:**Mục tiêu cá nhân, kế hoạch phát triển nghề nghiệp hoặc các khía cạnh mà người đó muốn cải thiện trong vị trí công việc hiện tại.

//Thông tin này giúp hiểu rõ về vai trò và trách nhiệm của người đó trong tổ chức, cũng như cung cấp cái nhìn tổng quan về sự phát triển và mục tiêu nghề nghiệp của họ.