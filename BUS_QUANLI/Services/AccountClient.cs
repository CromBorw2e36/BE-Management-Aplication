using DAL_QUANLI.Models.CustomModel;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.DataDB.UserData;
using quan_li_app.Services;
using quan_li_app.ViewModels.Data;

namespace BUS_QUANLI.Services
{
    public class AccountClient : StatusMessageMapper
    {
        private readonly DataContext _dataContext;
        private readonly CommonHelpers commonHelpers;
        private readonly ViewModelAccount viewModelAccount;
        private readonly TokenHelper tokenHelper;

        public AccountClient(DataContext pDataContext)
        {
            this._dataContext = pDataContext;
            this.viewModelAccount = new ViewModelAccount(pDataContext);
            this.commonHelpers = new CommonHelpers();
            this.tokenHelper = new TokenHelper();
        }

        public async Task<StatusMessage> AccountClientIns(AccountClientProfileModel acc)
        {
            if (acc == null)
            {
                return new StatusMessage(1, GetMessageDescription(EnumQuanLi.NoneData));
            }
            else
            {
                PasswordEndCodeDecodeMD5 encodePassword = new PasswordEndCodeDecodeMD5();
                Account account = acc.account;
                UserInfo userInfo = acc.userInfo;
                TOKEN token = acc.token;

                if (this.commonHelpers.CheckInValidVariableTypeString(account.account))
                {
                    return new StatusMessage(1, GetMessageDescription(EnumQuanLi.NotHaveUserName));
                }
                else if (this.commonHelpers.CheckInValidVariableTypeString(account.password))
                {
                    return new StatusMessage(1, GetMessageDescription(EnumQuanLi.NotHavePassword));
                }
                else if (this.commonHelpers.CheckInValidVariableTypeString(account.email)
                    && this.commonHelpers.CheckInValidVariableTypeString(account.phone)
                    )
                {
                    return new StatusMessage(1, GetMessageDescription(EnumQuanLi.ContactInformationRequired));
                }
                else if (this.commonHelpers.CheckInValidVariableTypeString(userInfo.name))
                {
                    userInfo.name = "Anonymous";
                }
                else if (this.commonHelpers.CheckInValidVariableTypeString(account.type_account) && this.commonHelpers.CheckInValidVariableTypeString(account.companyCode))
                {
                    return new StatusMessage(1, GetMessageDescription(EnumQuanLi.AccountTypeUnknown));
                }

                if (await this.viewModelAccount.AccountExists(account.account))
                {
                    return new StatusMessage(1, GetMessageDescription(EnumQuanLi.AccountExist));
                }
                else
                {
                    account.password = encodePassword.EndCodeMd5(account.password);
                    account.create_date = DateTime.Now;
                    userInfo.id = account.account;

                    try
                    {
                        string stringToken = await this.tokenHelper.GenTokenLogin(token, account.account);
                        _dataContext.Accounts.Add(account);
                        _dataContext.UserInfomation.Add(userInfo);
                        await _dataContext.SaveChangesAsync();
                        return new StatusMessage(0, GetMessageDescription(EnumQuanLi.RegisterSuccess), new AccountClientProfileModel
                        {
                            token = new TOKEN
                            {
                                Token = stringToken,
                            }
                        });
                    }
                    catch
                    {
                        return new StatusMessage(1, GetMessageDescription(EnumQuanLi.RegisterError));
                    }
                }

            }
        }
    }
}
