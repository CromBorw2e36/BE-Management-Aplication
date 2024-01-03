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
        UpdateError,
        UpdateSuccess,
        InsertSuccess,
        InsertError,
        DeleteSuccess,
        DeleteError,

        /// <summary>
        /// Action details
        /// </summary>

        NotHaveUserName,
        NotHavePassword,
        LoginSuccess,
        AccountDoesNotExist,
        AccountExist,
        InvalidPassword,
        NotFoundDictionary,
        ContactInformationRequired,
        RegisterSuccess,
        RegisterFail,
        RegisterError,
        AccountNotSameCompany,
        NotEnoughPermissions,

        /// <summary>
        /// Base
        /// </summary>

        ADMIN,
        NEWUSER,
    }
}
