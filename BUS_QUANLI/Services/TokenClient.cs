using Microsoft.AspNetCore.Http;
using quan_li_app.Helpers;
using quan_li_app.Helpers.Dictionary;
using quan_li_app.Models;
using quan_li_app.Models.DataDB;
using quan_li_app.ViewModels.Data;

namespace BUS_QUANLI.Services
{
    public class TokenClient : StatusMessageMapper
    {

        private readonly DataContext _dataContext;
        private readonly CommonHelpers commonHelpers;
        private readonly ViewModelAccount viewModelAccount;
        private readonly TokenHelper tokenHelper;

        public TokenClient(DataContext pDataContext)
        {
            this._dataContext = new DataContext();
            this.viewModelAccount = new ViewModelAccount();
            this.commonHelpers = new CommonHelpers();
            this.tokenHelper = new TokenHelper();
        }

        public void isConnecting(HttpContext httpContext, bool isConnecting = true)
        {
            string tokenString = tokenHelper.GetToken(httpContext.Request);
            TOKEN token = _dataContext.Tokens.FirstOrDefault(x => x.Token == tokenString)!;
            if (token != null)
            {
                token.is_connecting = isConnecting;
                _dataContext.SaveChanges();
            }
        }
    }
}
