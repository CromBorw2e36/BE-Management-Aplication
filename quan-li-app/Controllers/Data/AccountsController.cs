using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.Models.Common;
using quan_li_app.Models.DataDB;
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
        private readonly AccountService accountService;
        private readonly ViewModelAccount _viewModelAccount;
        private readonly StatusMessageMapper statusMessageMapper;


        public AccountsController(DataContext context)
        {
            _context = context;
            this._viewModelAccount = new ViewModelAccount(context);
            this.tokenHelper = new TokenHelper(context);
            this.accountService = new AccountService(context);
            this.statusMessageMapper = new StatusMessageMapper();
        }

        [HttpPost, Route("CheckTheExpirationDateOfToken")]
        public async Task<ActionResult<bool>> CheckTheExpirationDateOfToken()
        {
            try
            {
                return this.tokenHelper.CheckTheExpirationDateOfTheToken(HttpContext.Request);
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
        public async Task<ActionResult<StatusMessage>> Login(Account account)
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
                    // Sau này kiểm tra trạng thái của tài khoản có được login hay không là ở đây
                    // Nếu trả về data thì cho phép login
                    if (acc.password == EndcodePass)
                    {
                        //List<MenuPermissions> menuPermissions = await _context.MenuPermissions.Where(x => x.account == account.account).ToListAsync();
                        string newToken = await new TokenHelper(_context).GenToken(acc.account); // token

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
                            //menuPermissions
                        });
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
        [HttpPost("AddAccount")]
        public async Task<ActionResult<StatusMessage>> PostAccount(Account account)
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
            else if (account.phone == null || account.email == null)
            {
                StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.ContactInformationRequired));
                return message;
            }
            else
            {
                string EndCodePassword = new PasswordEndCodeDecodeMD5().EndCodeMd5(account.password);

                Account newAccount = new Account
                {
                    account = account.account,
                    password = EndCodePassword,
                    phone = account.phone,
                    status = null,
                    type_account = account.type_account,
                    email = account.email,
                    create_date = DateTime.Now,
                    last_enter = null,
                    lock_date = null,
                    companyCode = account.companyCode
                };

                _context.Accounts.Add(newAccount);
                try
                {
                    await _context.SaveChangesAsync();
                    StatusMessage message = new StatusMessage(1, statusMessageMapper.GetMessageDescription(EnumQuanLi.RegisterSuccess));
                    return message;
                }
                catch (DbUpdateException)
                {
                    if (AccountExists(account.account))
                    {
                        StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.AccountExist));
                        return message;
                    }
                    else
                    {
                        StatusMessage message = new StatusMessage(0, statusMessageMapper.GetMessageDescription(EnumQuanLi.RegisterError));
                        return message;
                    }
                }
            }
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
                    bool resUpdate = await accountService.UpdateAccountAsync(account);
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
