namespace quan_li_app.Models
{
    public enum EnumQuanLi
    {
        /// <summary>
        /// Request
        /// </summary>
        Unauthorized,

        /// <summary>
        /// Action CRUD
        /// </summary>
        /// 
        Suceeded,
        UpdateError,
        UpdateSuccess,
        InsertSuccess,
        InsertError,
        
        DeleteSuccess,
        DeleteError,
        DataExit,
        DataNotExit,

        /// <summary>
        /// Action details
        /// </summary>

        NotHaveUserName,
        NotHavePassword,
        LoginSuccess,
        AccountDoesNotExist,
        AccountExist,
        InvalidPassword,
        AccountIsBlocked,
        NotFoundDictionary,
        ContactInformationRequired,
        RegisterSuccess,
        RegisterFail,
        RegisterError,
        AccountNotSameCompany,
        NotEnoughPermissions,
        NoneData,
        AccountTypeUnknown,
        NotFoundItem,
        /// <summary>
        /// Base
        /// </summary>

        ADMIN,
        NEWUSER,
        VoucherFormNotCode,
        VoucherFormNotTable,
        GenRowTableNotCode,
        GenRowTableNotDataField,
        GenRowTableNotTable,
        GenRowTableNotDataType,
        SysMenuNotMenuID,
        DataNoCode,
        DataExists,
        DataNoName, 
        DataNoLevel,
        ChangePasswordError,
        Failded,
        PasswordIncorrect,
        ChangePasswordSuccess,
        LockSuccess,
        LockError,
        ApprovalError,
        ApprovalSuccess,
        ApprovalExits,
        LockExits,
        AccountStatusUnknow,
        ActionError,
    }
}
