using DAL_QUANLI.Models.CustomModel;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.DataDB.UserData;
using quan_li_app.Services;

namespace BUS_QUANLI.Services
{
    public class AccountClient : rootCommonService
    {
        public AccountClient()
        {
        }

        public async Task<StatusMessage<dynamic>> AccountClientIns(AccountClientProfileModel acc, string userName_create)
        {
            if (acc == null)
            {
                return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NoneData, userName_create));
            }
            else
            {
                PasswordEndCodeDecodeMD5 encodePassword = new PasswordEndCodeDecodeMD5();
                Account account = acc?.account!;
                UserInfo userInfo = acc?.userInfo!;
                TOKEN token = acc?.token!;

                if (this.commonHelpers.CheckInValidVariableTypeString(account?.account!))
                {
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotHaveUserName, userName_create));
                }
                else if (this.commonHelpers.CheckInValidVariableTypeString(account?.password!))
                {
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotHavePassword, userName_create));
                }
                else if (this.commonHelpers.CheckInValidVariableTypeString(account?.email!)
                    && this.commonHelpers.CheckInValidVariableTypeString(account?.phone!)
                    )
                {
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.ContactInformationRequired, userName_create));
                }
                else if (this.commonHelpers.CheckInValidVariableTypeString(userInfo?.name!))
                {
                    userInfo!.name = "Anonymous";
                }
                else if (this.commonHelpers.CheckInValidVariableTypeString(account?.type_account!) && this.commonHelpers.CheckInValidVariableTypeString(account?.companyCode!))
                {
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountTypeUnknown, userName_create));
                }

                if (await this.viewModelAccount.AccountExists(account?.account!))
                {
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountExist, userName_create));
                }
                else
                {
                    account!.password = encodePassword.EndCodeMd5(account?.password!);
                    account!.create_date = DateTime.Now;
                    account!.language = "vi-VN";
                    userInfo!.id = account.account;

                    try
                    {
                        string stringToken = await this.tokenHelper.GenTokenLogin(token, account?.account!);
                        dataContext.Accounts.Add(account!);
                        dataContext.UserInfomation.Add(userInfo);
                        await dataContext.SaveChangesAsync();
                        return new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.RegisterSuccess, userName_create), new AccountClientProfileModel
                        {
                            token = new TOKEN
                            {
                                Token = stringToken,
                            }
                        });
                    }
                    catch
                    {
                        return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.RegisterError, userName_create));
                    }
                }

            }
        }
    }
}
