using BUS_QUANLI.Services;
using DAL_QUANLI.Models.CustomModel;
using Microsoft.AspNetCore.Mvc;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.DataDB.UserData;
using quan_li_app.Services;
using quan_li_app.ViewModels.Data;

namespace quan_li_app.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly TokenHelper tokenHelper;
        private readonly ViewModelAccount _viewModelAccount;
        private readonly StatusMessageMapper statusMessageMapper;
        private readonly ViewModeUserInfo viewModeUserInfo;
        private readonly CommonHelpers commonHelpers;
        private readonly AccountClient _accoutnClient;

        public AccountsController(DataContext context, SystemContext systemContext)
        {
            _context = context;
            this._viewModelAccount = new ViewModelAccount();
            this.tokenHelper = new TokenHelper();
            this.statusMessageMapper = new StatusMessageMapper();
            this.viewModeUserInfo = new ViewModeUserInfo(context, systemContext);
            this.commonHelpers = new CommonHelpers();
            this._accoutnClient = new AccountClient();
        }

        [HttpPost, Route("CheckTheExpirationDateOfToken")]
        public ActionResult<bool> CheckTheExpirationDateOfToken()
        {
            try
            {
                if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
                {
                    return true;
                }
                return Unauthorized();
            }
            catch
            {
                return false;
            }
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<StatusMessage<dynamic>>> Login(AccountClientLoginParamsModel account)
        {
            if (account.account == null)
            {
                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotHaveUserName));
                return message;
            }
            else if (account.password == null)
            {
                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotHavePassword, account.account));
                return message;
            }
            else
            {
                string EndcodePass = new PasswordEndCodeDecodeMD5().EndCodeMd5(account.password);
                Account acc = _context.Accounts.FirstOrDefault(e => e.account == account.account)!;

                if (acc == null)
                {
                    StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountDoesNotExist, account.account));
                    return message;
                }
                else
                {
                    DateTime dateTimeNow = DateTime.Now;
                    DateTime lockDate = acc.lock_date ?? dateTimeNow;
                    if (acc.password == EndcodePass && lockDate <= dateTimeNow)
                    {
                        account.ip_address = HttpContext.Connection.RemoteIpAddress!.ToString(); ;
                        string newToken = await new TokenHelper().GenTokenLogin(account); // token
                        UserInfo user = _context.UserInfomation.FirstOrDefault(x => x.id == acc.account)!;

                        acc.last_enter = DateTime.Now;
                        acc.token = newToken;
                        _context.Accounts.Update(acc);
                        _context.SaveChanges();

                        StatusMessage<dynamic> message = new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.LoginSuccess, account.account), new
                        {
                            account = new Account
                            {
                                account = acc.account,
                                create_date = acc.create_date,
                                lock_date = acc.lock_date,
                                phone = acc.phone,
                                status = acc.status,
                                type_account = acc.type_account,
                                email = acc.email,
                                token = newToken
                            },
                            user = user,
                            //menuPermissions
                        });

                        return message;
                    }
                    else if (lockDate > dateTimeNow)
                    {
                        string additionalMsg = this.commonHelpers.DateCalculatingYearMonthDate(lockDate, dateTimeNow, _viewModelAccount.getLanguageByUserName(account.account));
                        StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountIsBlocked, account.account) + " " + additionalMsg);
                        return message;
                    }
                    else
                    {
                        StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InvalidPassword, account.account));
                        return message;
                    }

                }

            }
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AccountIns")]
        public async Task<ActionResult<StatusMessage<dynamic>>> AccountIns(AccountClientProfileModel profile)
        {
            string userName = this.tokenHelper.GetUsername(HttpContext.Request);
            StatusMessage<dynamic> msg = new StatusMessage<dynamic>();
            msg = await _accoutnClient.AccountClientIns(profile, userName);
            return msg;
        }

        [HttpPost("UpdateAccount")]
        public async Task<ActionResult<StatusMessage<dynamic>>> UpdateAccount(Account account)
        {
            string UsernameCredential = tokenHelper.GetUsername(HttpContext.Request);
            if (!AccountExists(account.account!))
            {
                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountDoesNotExist, UsernameCredential));
                return message;
            }
            else
            {

                if (UsernameCredential.Equals(account.account)) //  Tự cập nhật thông tin các nhân
                {
                    bool resUpdate = await _viewModelAccount.UpdateAccountAsync(account);
                    string mess = statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError, UsernameCredential);

                    if (resUpdate)
                    {
                        mess = statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess, UsernameCredential);

                    }

                    StatusMessage<dynamic> message = new StatusMessage<dynamic>(resUpdate ? 1 : 0, mess);
                    return message;
                }
                else
                {
                    if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
                    {
                        Account accountRequest = _viewModelAccount.GetAccountByUsername(UsernameCredential);
                        Account accountUpdate = _viewModelAccount.GetAccountByUsername(account.account!);
                        if (accountRequest != null && accountUpdate != null)
                        {
                            // kiểm tra công ty, kiểm tra quyền
                            // Thông tin cũ của người dùng cần cập nhật

                            if (!accountRequest.companyCode!.Equals(accountUpdate.companyCode))
                            {
                                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountNotSameCompany, UsernameCredential));
                                return message;
                            }
                            else if (!(accountRequest.levelPermision > accountUpdate.levelPermision))
                            {
                                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess, UsernameCredential));
                                return message;
                            }
                            else if (accountRequest.levelPermision > accountUpdate.levelPermision)
                            {
                                bool result = await _viewModelAccount.UpdateAccountAsync(account);

                                StatusMessage<dynamic> message = new StatusMessage<dynamic>(0,
                                    result
                                    ? statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess, UsernameCredential)
                                    : statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError, UsernameCredential)
                                    );
                                return message;
                            }
                            else
                            {
                                return Unauthorized(statusMessageMapper.GetMessageDescription(EnumQuanLi.Unauthorized, UsernameCredential));
                            }
                        }
                    }
                    else
                    {
                        return Unauthorized(statusMessageMapper.GetMessageDescription(EnumQuanLi.Unauthorized, UsernameCredential));
                    }
                }
            }
            return NoContent();
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<StatusMessage<dynamic>> DeleteAccount(string id)
        {
            string UsernameCredential = tokenHelper.GetUsername(HttpContext.Request);
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                StatusMessage<dynamic> message2 = new StatusMessage<dynamic>(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountDoesNotExist, UsernameCredential));
                return message2;
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            StatusMessage<dynamic> message = new StatusMessage<dynamic>(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.DeleteSuccess, UsernameCredential));
            return message;
        }

        private bool AccountExists(string id)
        {
            return _context.Accounts.Any(e => e.account == id);
        }
    }
}
