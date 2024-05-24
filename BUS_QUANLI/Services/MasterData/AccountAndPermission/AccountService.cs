using BUS_QUANLI.Services.MasterData;
using DAL_QUANLI.Interface.MasterData;
using DAL_QUANLI.Models.CustomModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.DataDB.UserData;

namespace BUS_QUANLI.Services.MasterData.AccountAndPermission
{
    public class AccountService : rootCommonService, IAccountService
    {

        string statusApproval = "3";
        string statusWaitActive = "4";
        string statusLock = "1";
        public string _tablename = "Account";
        public string _tableName2 = "UserInfomation";

        public AccountService()
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

                if (commonHelpers.CheckInValidVariableTypeString(account?.account!))
                {
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotHaveUserName, userName_create));
                }
                else if (commonHelpers.CheckInValidVariableTypeString(account?.password!))
                {
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotHavePassword, userName_create));
                }
                else if (commonHelpers.CheckInValidVariableTypeString(account?.email!)
                    && commonHelpers.CheckInValidVariableTypeString(account?.phone!)
                    )
                {
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.ContactInformationRequired, userName_create));
                }
                else if (commonHelpers.CheckInValidVariableTypeString(userInfo?.name!))
                {
                    userInfo!.name = "Anonymous";
                }
                else if (commonHelpers.CheckInValidVariableTypeString(account?.type_account!) && commonHelpers.CheckInValidVariableTypeString(account?.companyCode!))
                {
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountTypeUnknown, userName_create));
                }
                else if (commonHelpers.CheckInValidVariableTypeString(account.status))
                {
                    return new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountStatusUnknow, userName_create));
                }

                if (await viewModelAccount.AccountExists(account?.account!))
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
                        string stringToken = await tokenHelper.GenTokenLogin(token, account?.account!);
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

        public StatusMessage<dynamic> Approval(HttpRequest httpRequest, Account model)
        {
            try
            {
                if (model.account == null)
                    return new StatusMessage<dynamic>(1, GetMessageDescription(EnumQuanLi.DataNoCode, httpRequest));
                var result = dataContext.Accounts.Where(x => x.account == model.account && model.companyCode == x.companyCode).FirstOrDefault();
                if (result == null)
                {
                    return new StatusMessage<dynamic>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }
                else if (result.status != statusWaitActive)
                {
                    return new StatusMessage<dynamic>(0, GetMessageDescription(EnumQuanLi.ApprovalExits, httpRequest));
                }
                else
                {
                    result.status = statusApproval;
                    dataContext.SaveChanges();
                    return new StatusMessage<dynamic>(0, GetMessageDescription(EnumQuanLi.ApprovalSuccess, httpRequest));
                }
            }
            catch
            {
                return new StatusMessage<dynamic>(1, GetMessageDescription(EnumQuanLi.ApprovalError, httpRequest));
            }
        }

        public StatusMessage<dynamic> ChangePassword(HttpRequest httpRequest, Account model)
        {
            try
            {
                if (model.account == null)
                    return new StatusMessage<dynamic>(1, GetMessageDescription(EnumQuanLi.DataNoCode, httpRequest));
                var result = dataContext.Accounts.Where(x => x.account == model.account && model.companyCode == x.companyCode).FirstOrDefault();
                if (result == null)
                {
                    return new StatusMessage<dynamic>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }
                else
                {
                    PasswordEndCodeDecodeMD5 encodePassword = new PasswordEndCodeDecodeMD5();
                    string confirmPassword = encodePassword.EndCodeMd5(model.password);
                    if (confirmPassword != result.password)
                    {
                        return new StatusMessage<dynamic>(1, GetMessageDescription(EnumQuanLi.PasswordIncorrect, httpRequest));
                    }
                    result.password = encodePassword.EndCodeMd5(model.password1!);
                    dataContext.SaveChanges();
                    return new StatusMessage<dynamic>(0, GetMessageDescription(EnumQuanLi.ChangePasswordSuccess, httpRequest));
                }
            }
            catch
            {
                return new StatusMessage<dynamic>(1, GetMessageDescription(EnumQuanLi.ChangePasswordError, httpRequest));
            }
        }

        public StatusMessage<Account> Delete(HttpRequest httpRequest, Account model)
        {
            try
            {
                if (model.account == null)
                    return new StatusMessage<Account>(1, GetMessageDescription(EnumQuanLi.DataNoCode, httpRequest), new Account());
                var result = dataContext.Accounts.Where(x => x.account == model.account).FirstOrDefault();
                var result2 = dataContext.UserInfomation.Where(x => x.id == model.account).ToList();
                if (result == null)
                {
                    return new StatusMessage<Account>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new Account());
                }
                else
                {

                    dataContext.Accounts.Remove(result);
                    if (result2.Count > 0)
                    {
                        dataContext.UserInfomation.RemoveRange(result2);
                    }
                    dataContext.SaveChanges();
                    return new StatusMessage<Account>(0, GetMessageDescription(EnumQuanLi.DeleteSuccess, httpRequest), new Account());
                }
            }
            catch
            {
                return new StatusMessage<Account>(1, GetMessageDescription(EnumQuanLi.DeleteError, httpRequest), new Account());
            }
        }

        public StatusMessage<List<UserInfoGetListModel>> GetListUser(HttpRequest httpRequest, Account model)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter("@pcompanyCode", tokenHelper.GetCompanyCode(httpRequest)));
                parameters.Add(new SqlParameter("@pstatus", model.status != null ? model.status : DBNull.Value));


                var result = dataContext.Database.SqlQueryRaw<UserInfoGetListModel>(
                "EXEC GetListUserByStatus @pcompanyCode, @pstatus", parameters.ToArray()
                ).ToList();


                return new StatusMessage<List<UserInfoGetListModel>>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), result);
            }
            catch
            {
                return new StatusMessage<List<UserInfoGetListModel>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<UserInfo>());
            }
        }

        public StatusMessage<dynamic> Lock(HttpRequest httpRequest, Account model)
        {
            try
            {
                if (model.account == null)
                    return new StatusMessage<dynamic>(1, GetMessageDescription(EnumQuanLi.DataNoCode, httpRequest));
                var result = dataContext.Accounts.Where(x => x.account == model.account && model.companyCode == x.companyCode).FirstOrDefault();
                if (result == null)
                {
                    return new StatusMessage<dynamic>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest));
                }
                else if (result.status == statusLock)
                {
                    return new StatusMessage<dynamic>(0, GetMessageDescription(EnumQuanLi.LockExits, httpRequest));
                }
                else
                {
                    result.status = statusLock;
                    dataContext.SaveChanges();
                    return new StatusMessage<dynamic>(0, GetMessageDescription(EnumQuanLi.LockSuccess, httpRequest));
                }
            }
            catch
            {
                return new StatusMessage<dynamic>(1, GetMessageDescription(EnumQuanLi.LockError, httpRequest));
            }
        }

        public StatusMessage<AccountClientProfileModel> Search(HttpRequest httpRequest, Account model)
        {
            try
            {
                if (model.account != null)
                {
                    var result = dataContext.Accounts.Where(x => x.account == model.account && x.companyCode == model.companyCode).ToList();
                    var result2 = dataContext.UserInfomation.Where(x => x.id == model.account && x.codeCompany == model.companyCode).ToList();
                    result[0].password = "";
                    AccountClientProfileModel oPP = new AccountClientProfileModel()
                    {
                        account = result[0],
                        userInfo = result2[0],
                        token = null
                    };


                    return new StatusMessage<AccountClientProfileModel>(0, GetMessageDescription(EnumQuanLi.Suceeded, httpRequest), oPP);
                }
                else
                {
                    return new StatusMessage<AccountClientProfileModel>(1, GetMessageDescription(EnumQuanLi.DataNoCode, httpRequest), new AccountClientProfileModel());
                }
            }
            catch
            {
                return new StatusMessage<AccountClientProfileModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new AccountClientProfileModel());
                //return new StatusMessage<List<AccountClientProfileModel>>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new List<AccountClientProfileModel>());
            }
        }

        public StatusMessage<AccountClientProfileModel> Update(HttpRequest httpRequest, AccountClientProfileModel model)
        {
            try
            {
                if (model.account.account == null)
                {
                    return new StatusMessage<AccountClientProfileModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new AccountClientProfileModel());
                }
                else
                {
                    var accountFind = dataContext.Accounts.Where(x => x.account == model.account.account && x.companyCode == model.account.companyCode).FirstOrDefault();
                    var userInfoFind = dataContext.UserInfomation.Where(x => x.id == model.account.account && x.codeCompany == model.account.companyCode).FirstOrDefault();
                    if (accountFind != null && userInfoFind != null)
                    {
                        model.account.password = accountFind.password; // Giữ password cũ của người dùng
                        model.account.create_date = accountFind.create_date;
                        model.account.lock_date = accountFind.lock_date;
                        model.account.last_enter = accountFind.last_enter;

                        model.userInfo.modifyDate = DateTime.Now;

                        dataContext.Accounts.Remove(accountFind);
                        dataContext.Accounts.Add(model.account);

                        dataContext.UserInfomation.Remove(userInfoFind);
                        dataContext.UserInfomation.Add(model.userInfo);

                        dataContext.SaveChanges();

                        return new StatusMessage<AccountClientProfileModel>(0, GetMessageDescription(EnumQuanLi.UpdateSuccess, httpRequest), model);
                    }
                    else
                    {
                        return new StatusMessage<AccountClientProfileModel>(1, GetMessageDescription(EnumQuanLi.NotFoundItem, httpRequest), new AccountClientProfileModel());
                    }
                }
            }
            catch
            {
                return new StatusMessage<AccountClientProfileModel>(1, GetMessageDescription(EnumQuanLi.UpdateError, httpRequest), new AccountClientProfileModel());
            }
        }

        public StatusMessage<List<UserInfoGetListModel>> GetListUserRegister(HttpRequest httpRequest, Account model)
        {
            model.status = statusWaitActive;
            return GetListUser(httpRequest, model);

        }
    }
}
