using Microsoft.EntityFrameworkCore;
using quan_li_app.Models;
using quan_li_app.Models.DataDB;
using quan_li_app.Services;

namespace quan_li_app.ViewModels.Data
{
    public class ViewModelAccount
    {
        private readonly DataContext _dbContext;
        public ViewModelAccount(DataContext context)
        {
            _dbContext = context;
        }

        public Account GetAccountByUsername(string username)
        {
            try
            {
                Account account = ((Account)(from a in _dbContext.Accounts
                                             join b in _dbContext.SysPermissions on a.codePermision equals b.code
                                             select new Account
                                             {
                                                 account = a.account,
                                                 password = "",
                                                 status = a.status,
                                                 create_date = a.create_date,
                                                 lock_date = a.lock_date,
                                                 last_enter = a.last_enter,
                                                 email = a.email,
                                                 phone = a.phone,
                                                 type_account = a.type_account,
                                                 token = a.token,
                                                 codePermision = a.codePermision,
                                                 companyCode = a.companyCode,
                                                 levelPermision = b.level,
                                                 namePermision = b.name
                                             }));

                return account;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> UpdateAccountAsync(Account account)
        {
            // Update
            Account acc = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.account == account.account);
            if (account.password is not null)
            {
                string newPassword = new PasswordEndCodeDecodeMD5().EndCodeMd5(account.password);
                if (newPassword != acc.password)
                {
                    acc.password = newPassword;
                }

                acc.lock_date = account.lock_date is not null ? account.lock_date : acc.lock_date;
                acc.email = account.email is not null ? account.email : acc.email;
                acc.phone = account.phone is not null ? account.phone : acc.phone;
                acc.type_account = account.type_account is not null ? account.type_account : acc.type_account;
                acc.status = account.status is not null ? account.status : acc.status;

                try
                {
                    _dbContext.Accounts.Update(acc);
                    await _dbContext.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteAccountByUsername(string username)
        {
            try
            {
                Account account = GetAccountByUsername(username);
                if (account != null)
                {
                    _dbContext.Remove(account);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> AccountExists(string id)
        {
            return _dbContext.Accounts.Any(e => e.account == id);
        }

        public async Task<bool> AccountIns(Account acc)
        {
            try
            {
                _dbContext.Accounts.Add(acc);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
