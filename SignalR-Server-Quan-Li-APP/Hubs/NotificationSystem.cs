using Microsoft.AspNetCore.SignalR;
using quan_li_app.Helpers;
using quan_li_app.Models;
using quan_li_app.Models.DataDB;
using quan_li_app.Models.DataDB.UserData;

namespace SignalR_Server_Quan_Li_APP.Hubs
{
    public class NotificationSystem : Hub
    {
        private readonly DataContext _dataContext;
        private readonly TokenHelper _tokenHelper;

        public NotificationSystem(DataContext dataContext, TokenHelper tokenHelper)
        {
            this._dataContext = dataContext;
            this._tokenHelper = tokenHelper;
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            string connectionId = Context.ConnectionId;
            string getToken = _tokenHelper.GetToken(httpContext.Request);
            string getUser = _tokenHelper.GetUsername(httpContext.Request);
            TOKEN tokenByUsername = _dataContext.Tokens.FirstOrDefault(x => x.Token == getToken);
            if (tokenByUsername.connectionSignalID != connectionId)
            {
                tokenByUsername.connectionSignalID = connectionId;
                _dataContext.Tokens.Update(tokenByUsername);
                _dataContext.SaveChanges();
            }
            await base.OnConnectedAsync();
        }

        public async Task NotifycationSubscribe(UserInfo user, string msg)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, "Thông báo");
        }
    }
}
