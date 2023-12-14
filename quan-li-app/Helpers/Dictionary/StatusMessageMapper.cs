using quan_li_app.Models;

namespace quan_li_app.Helpers.Dictionary
{
    public class StatusMessageMapper
    {
        private Dictionary<EnumQuanLi, string> statusMessageMapper;
        public StatusMessageMapper()
        {
            statusMessageMapper = new Dictionary<EnumQuanLi, string>
            {
                {EnumQuanLi.Unauthorized, "Phiên đăng nhập đã hết hạn" },
                {EnumQuanLi.UpdateError, "Xảy ra lỗi khi cập nhật" },
                {EnumQuanLi.UpdateSuccess, "Cập nhật thành công" },
                {EnumQuanLi.AccountDoesNotExist, "Không tìm thấy tài khoản" },
                {EnumQuanLi.InsertSuccess, "Thêm mới thành công" },
                {EnumQuanLi.InsertError, "Xảy ra lỗi khi thêm mới" },
                {EnumQuanLi.NotFoundDictionary, "Không tìm thấy mô tả cho message này" },
                {EnumQuanLi.NotHaveUserName, "Không nhập tài khoản" },
                {EnumQuanLi.NotHavePassword, "Không nhập mật khẩu" },
                {EnumQuanLi.LoginSuccess, "Đăng nhập thành công" },
                {EnumQuanLi.InvalidPassword, "Sai mật khẩu" },
                {EnumQuanLi.AccountExist, "Tài khoản tồn tại" },
                {EnumQuanLi.ContactInformationRequired, "Yêu cầu phải có thông tin liên hệ" },
                {EnumQuanLi.RegisterError,  "Xảy ra lỗi khi đăng kí" },
                {EnumQuanLi.RegisterFail,   "Đăng kí thất bại" },
                {EnumQuanLi.RegisterSuccess, "Đăng kí thành công" },
                {EnumQuanLi.AccountNotSameCompany, "Không cùng công ty (Lỗi kết xuất dữ liệu)" },
                {EnumQuanLi.NotEnoughPermissions, "Vượt quá quyền thao tác" },
            };
        }

        public string GetMessageDescription(EnumQuanLi param)
        {
            if (statusMessageMapper.ContainsKey(param))
            {
                return statusMessageMapper[param];
            }
            else
            {
                return statusMessageMapper[EnumQuanLi.NotFoundDictionary];
            }
        }

    }
}
