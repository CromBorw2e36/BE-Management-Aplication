using Microsoft.EntityFrameworkCore;
using quan_li_app.Models;
using quan_li_app.Models.DataDB;

namespace quan_li_app.Services
{
    public class AccountService
    {
        private readonly DataContext _dataContext;
        private readonly SystemContext _systemContext;

        public AccountService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public AccountService(DataContext dataContext, SystemContext systemContext)
        {
            _dataContext = dataContext;
            _systemContext = systemContext;
        }


        public async Task<bool> AccountExists(string id)
        {
            return _dataContext.Accounts.Any(e => e.account == id);
        }

        public async Task<Account> GetAccountAsync(string id)
        {
            Account account = await _dataContext.Accounts.FindAsync(id);
            return account;
        }

        public async Task<bool> UpdateAccountAsync(Account account)
        {
            // Update
            Account acc = await _dataContext.Accounts.FirstOrDefaultAsync(x => x.account == account.account);
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
                    _dataContext.Accounts.Update(acc);
                    await _dataContext.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }

    }
}
