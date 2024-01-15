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
            this._viewModelAccount = new ViewModelAccount(context);
            this.tokenHelper = new TokenHelper(context);
            this.statusMessageMapper = new StatusMessageMapper();
            this.viewModeUserInfo = new ViewModeUserInfo(context, systemContext);
            this.commonHelpers = new CommonHelpers();
            this._accoutnClient = new AccountClient(context);
        }

        [HttpPost, Route("CheckTheExpirationDateOfToken")]
        public async Task<ActionResult<bool>> CheckTheExpirationDateOfToken()
        {
            try
            {
                if (this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
                {
                    return true;
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<StatusMessage>> Login(AccountClientLoginParamsModel account)
        {

            if (account.account == null)
            {
                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotHaveUserName));
                return message;
            }
            else if (account.password == null)
            {
                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.NotHavePassword));
                return message;
            }
            else
            {
                string EndcodePass = new PasswordEndCodeDecodeMD5().EndCodeMd5(account.password);
                Account acc = _context.Accounts.FirstOrDefault(e => e.account == account.account);

                if (acc == null)
                {
                    StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountDoesNotExist));
                    return message;
                }
                else
                {
                    DateTime dateTimeNow = DateTime.Now;
                    DateTime lockDate = acc.lock_date ?? dateTimeNow;
                    if (acc.password == EndcodePass && lockDate <= dateTimeNow)
                    {
                        string newToken = await new TokenHelper(_context).GenTokenLogin(account); // token
                        UserInfo user = _context.UserInfomation.FirstOrDefault(x => x.id == acc.account);

                        acc.last_enter = DateTime.Now;
                        acc.token = newToken;
                        _context.Accounts.Update(acc);
                        _context.SaveChanges();

                        StatusMessage message = new StatusMessage(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.LoginSuccess), new
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
                        string additionalMsg = this.commonHelpers.DateCalculatingYearMonthDate(lockDate, dateTimeNow);
                        StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountIsBlocked) + " " + additionalMsg);
                        return message;
                    }
                    else
                    {
                        StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.InvalidPassword));
                        return message;
                    }

                }

            }
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AccountIns")]
        public async Task<ActionResult<StatusMessage>> AccountIns(AccountClientProfileModel profile)
        {
            StatusMessage msg = new StatusMessage();
            msg = await _accoutnClient.AccountClientIns(profile);
            return msg;
        }

        [HttpPost("UpdateAccount")]
        public async Task<ActionResult<StatusMessage>> UpdateAccount(Account account)
        {
            if (!AccountExists(account.account))
            {
                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountDoesNotExist));
                return message;
            }
            else
            {
                // Kiểm tra quyền người dùng
                string UsernameCredential = tokenHelper.GetUsername(HttpContext.Request);
                if (UsernameCredential.Equals(account.account)) //  Tự cập nhật thông tin các nhân
                {
                    bool resUpdate = await _viewModelAccount.UpdateAccountAsync(account);
                    string mess = statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError);

                    if (resUpdate)
                    {
                        mess = statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess);

                    }

                    StatusMessage message = new StatusMessage(resUpdate ? 1 : 0, mess);
                    return message;
                }
                else
                {
                    if (tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request))
                    {
                        Account accountRequest = _viewModelAccount.GetAccountByUsername(UsernameCredential);
                        Account accountUpdate = _viewModelAccount.GetAccountByUsername(account.account);
                        if (accountRequest != null && accountUpdate != null)
                        {
                            // kiểm tra công ty, kiểm tra quyền
                            // Thông tin cũ của người dùng cần cập nhật

                            if (!accountRequest.companyCode.Equals(accountUpdate.companyCode))
                            {
                                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountNotSameCompany));
                                return message;
                            }
                            else if (!(accountRequest.levelPermision > accountUpdate.levelPermision))
                            {
                                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess));
                                return message;
                            }
                            else if (accountRequest.levelPermision > accountUpdate.levelPermision)
                            {
                                bool result = await _viewModelAccount.UpdateAccountAsync(account);

                                StatusMessage message = new StatusMessage(0,
                                    result
                                    ? statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateSuccess)
                                    : statusMessageMapper.GetMessageDescription(EnumQuanLi.UpdateError)
                                    );
                                return message;
                            }
                            else
                            {
                                return Unauthorized(statusMessageMapper.GetMessageDescription(EnumQuanLi.Unauthorized));
                            }
                        }
                    }
                    else
                    {
                        return Unauthorized(statusMessageMapper.GetMessageDescription(EnumQuanLi.Unauthorized));
                    }
                }
            }
            return null;
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<StatusMessage> DeleteAccount(string id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                StatusMessage message2 = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountDoesNotExist));
                return message2;
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            StatusMessage message = new StatusMessage(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.DeleteSuccess));
            return message;
        }

        private bool AccountExists(string id)
        {
            return _context.Accounts.Any(e => e.account == id);
        }
    }
}
