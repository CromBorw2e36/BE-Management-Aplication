using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.DataDB;

namespace quan_li_app.Helpers.Dictionary
{
    public class StatusMessageMapper
    {
        private Dictionary<EnumQuanLi, string> statusMessageMapper;
        private Dictionary<EnumQuanLi, string> statusMessageMapperOther;
        private readonly DataContext _dataContext;



        public StatusMessageMapper()
        {
            _dataContext = new DataContext();
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
                {EnumQuanLi.AccountIsBlocked, "Tài khoản đã bị khóa trong khoảng " },
                {EnumQuanLi.NoneData, "Không có dữ liệu" },
                {EnumQuanLi.AccountTypeUnknown, "Không xác định được loại người dùng" },
                {EnumQuanLi.NotFoundItem, "Không tìm thấy đối tượng trong CSDL của quý khách" },
                {EnumQuanLi.DeleteSuccess, "Xóa thành công" },
                {EnumQuanLi.DeleteError, "Xóa thất bại" },
                {EnumQuanLi.DataExit, "Dữ liệu tồn tại" },
                {EnumQuanLi.DataNotExit, "Dữ liệu không tồn tại" },
                {EnumQuanLi.VoucherFormNotCode, "DataField chưa có giá trị" },
                {EnumQuanLi.VoucherFormNotTable, "Table chưa có giá trị" },
                {EnumQuanLi.Suceeded, "Thực hiện thành công" },
                {EnumQuanLi.GenRowTableNotCode, "Object have \"code\" isn't value" },
                {EnumQuanLi.GenRowTableNotDataField, "Object have \"data field\" isn't value" },
                {EnumQuanLi.GenRowTableNotTable, "Object have \"table name\" isn't value" },
                {EnumQuanLi.GenRowTableNotDataType, "Object have \"data type\" isn't value" },
                {EnumQuanLi.SysMenuNotMenuID, "Object have \"menuid\" isn't value" },
                {EnumQuanLi.DataExists, "Dữ liệu tồn tại!" },
                {EnumQuanLi.DataNoCode, "Chưa khởi tạo mã" },
                {EnumQuanLi.DataNoName, "Chưa khởi tạo tên" },
                {EnumQuanLi.DataNoLevel, "Chưa khởi tạo cấp độ" },
                {EnumQuanLi.ChangePasswordError, "Đổi mật khẩu thất bại" },
                {EnumQuanLi.Failded, "Không thành công!" },
                {EnumQuanLi.ChangePasswordSuccess, "Thay đổi thành công mật khẩu" },
                {EnumQuanLi.PasswordIncorrect, "Mật khẩu không khớp" },
                {EnumQuanLi.LockError, "Khóa tài khoản thât bại" },
                {EnumQuanLi.LockSuccess, "Khóa tài khoảng thành công" },
                {EnumQuanLi.ApprovalSuccess, "Đã duyệt tài khoản" },
                {EnumQuanLi.ApprovalError, "Không thể duyệt tài khoản này" },
                {EnumQuanLi.ApprovalExits, "Không thể duyệt tài khoản đã được duyệt" },
                {EnumQuanLi.LockExits, "Tài khoản này đẫ được khóa trước đó" },
            };

            statusMessageMapperOther = new Dictionary<EnumQuanLi, string>
            {
                {EnumQuanLi.Unauthorized, "The login session has expired" },
                {EnumQuanLi.UpdateError, "An error occurred while updating" },
                {EnumQuanLi.UpdateSuccess, "Update successful" },
                {EnumQuanLi.AccountDoesNotExist, "Account not found" },
                {EnumQuanLi.InsertSuccess,"Successfully added new" },
                {EnumQuanLi.InsertError, "There was an error adding new" },
                {EnumQuanLi.NotFoundDictionary, "No description found for this message" },
                {EnumQuanLi.NotHaveUserName,"No account entered" },
                {EnumQuanLi.NotHavePassword, "No password entered" },
                {EnumQuanLi.LoginSuccess, "Login successful" },
                {EnumQuanLi.InvalidPassword, "Wrong password" },
                {EnumQuanLi.AccountExist, "Account exists" },
                {EnumQuanLi.ContactInformationRequired, "A contact information is required for the request" },
                {EnumQuanLi.RegisterError,  "There was an error during registration"},
                {EnumQuanLi.RegisterFail,  "Registration failed" },
                {EnumQuanLi.RegisterSuccess, "Registration successful" },
                {EnumQuanLi.AccountNotSameCompany, "Not from the same company (Data export error)" },
                {EnumQuanLi.NotEnoughPermissions, "Exceeded operational permissions" },
                {EnumQuanLi.AccountIsBlocked, "The account has been locked for a period of " },
                {EnumQuanLi.NoneData, "None data" },
                {EnumQuanLi.AccountTypeUnknown, "The account type is unknown" },
                {EnumQuanLi.NotFoundItem, "Not found item in your database" },
                {EnumQuanLi.DeleteSuccess, "Delete is success" },
                {EnumQuanLi.DeleteError, "Delete is error" },
                {EnumQuanLi.DataExit, "Data is exit" },
                {EnumQuanLi.DataNotExit, "Data isn't exit" },
                {EnumQuanLi.VoucherFormNotCode, "DataField isn't exit" },
                {EnumQuanLi.VoucherFormNotTable, "Table isn't exit" },
                {EnumQuanLi.Suceeded, "Successed" },
                {EnumQuanLi.GenRowTableNotCode, "Object have \"code\" isn't value" },
                {EnumQuanLi.GenRowTableNotDataField, "Object have \"data field\" isn't value" },
                {EnumQuanLi.GenRowTableNotTable, "Object have \"table name\" isn't value" },
                {EnumQuanLi.GenRowTableNotDataType, "Object have \"data type\" isn't value" },
                {EnumQuanLi.SysMenuNotMenuID, "Object have \"menuid\" isn't value" },
                {EnumQuanLi.DataExists, "Data is exists!" },
                {EnumQuanLi.DataNoCode, "Not value key" },
                {EnumQuanLi.DataNoName, "Please enter name" },
                {EnumQuanLi.DataNoLevel, "Please enter level" },
                {EnumQuanLi.ChangePasswordError, "Change password Error" },
                {EnumQuanLi.Failded, "Acount failed!" },
                {EnumQuanLi.ChangePasswordSuccess, "Change password success" },
                {EnumQuanLi.PasswordIncorrect, "Password and password confirm don't match" },
                {EnumQuanLi.LockError, "Lock account successed" },
                {EnumQuanLi.LockSuccess, "Lock account failed" },
                {EnumQuanLi.ApprovalSuccess, "Approval account successed" },
                {EnumQuanLi.ApprovalError, "Approval account failed" },
                {EnumQuanLi.ApprovalExits, "Account was approvaled" },
                {EnumQuanLi.LockExits, "Account was Lock" },


            };
        }

        public string GetMessageDescription(EnumQuanLi param)
        {
            string language = "ORTHER";
            switch (language)
            {
                case "vi-VN":
                    if (statusMessageMapper.ContainsKey(param))
                    {
                        return statusMessageMapper[param];
                    }
                    else
                    {
                        return statusMessageMapper[EnumQuanLi.NotFoundDictionary];
                    }
                case "ORTHER":
                    if (statusMessageMapperOther.ContainsKey(param))
                    {
                        return statusMessageMapperOther[param];
                    }
                    else
                    {
                        return statusMessageMapperOther[EnumQuanLi.NotFoundDictionary];
                    }
                default:
                    return statusMessageMapperOther[EnumQuanLi.NotFoundDictionary];
            }
        }

        public string GetMessageDescription(EnumQuanLi param, string account = "")
        {
            string language = "ORTHER";
            if (account != null && account.Length > 0)
            {
                Account obj = _dataContext.Accounts.Where(x => x.account.Equals(account)).FirstOrDefault();
                if (obj != null)
                {
                    language = obj.language;
                }
            }
            switch (language)
            {
                case "vi-VN":
                    if (statusMessageMapper.ContainsKey(param))
                    {
                        return statusMessageMapper[param];
                    }
                    else
                    {
                        return statusMessageMapper[EnumQuanLi.NotFoundDictionary];
                    }
                case "ORTHER":
                    if (statusMessageMapperOther.ContainsKey(param))
                    {
                        return statusMessageMapperOther[param];
                    }
                    else
                    {
                        return statusMessageMapperOther[EnumQuanLi.NotFoundDictionary];
                    }
                default:
                    return statusMessageMapperOther[EnumQuanLi.NotFoundDictionary];
            }
        }

        public string GetMessageDescription(EnumQuanLi param, HttpRequest httpRequest)
        {
            string language = "ORTHER";
            string account = TokenHelper.GetUsername_2(httpRequest);
            if (account != null && account.Length > 0)
            {
                Account obj = _dataContext.Accounts.Where(x => x.account.Equals(account)).FirstOrDefault();
                if (obj != null)
                {
                    language = obj.language;
                }
            }
            switch (language)
            {
                case "vi-VN":
                    if (statusMessageMapper.ContainsKey(param))
                    {
                        return statusMessageMapper[param];
                    }
                    else
                    {
                        return statusMessageMapper[EnumQuanLi.NotFoundDictionary];
                    }
                case "ORTHER":
                    if (statusMessageMapperOther.ContainsKey(param))
                    {
                        return statusMessageMapperOther[param];
                    }
                    else
                    {
                        return statusMessageMapperOther[EnumQuanLi.NotFoundDictionary];
                    }
                default:
                    return statusMessageMapperOther[EnumQuanLi.NotFoundDictionary];
            }
        }

    }
}
