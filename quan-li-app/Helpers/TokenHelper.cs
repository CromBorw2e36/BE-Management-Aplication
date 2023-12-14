using quan_li_app.Models;
using quan_li_app.Models.DataDB;
using quan_li_app.Services;
using System.Security.Claims;

namespace quan_li_app.Helpers
{
    public class TokenHelper
    {
        private readonly DataContext _contextData;
        public TokenHelper(DataContext dataContext)
        {
            _contextData = dataContext;
        }

        public async Task<string> GenToken(string username)
        {
            TokenService tokenService = new TokenService();
            string token = tokenService.GenerateToken(username);
            TOKEN obj = new TOKEN();

            obj.id = Guid.NewGuid().ToString();
            obj.Token = token;
            obj.username = username;
            obj.date = DateTime.Now;
            obj.endDate = DateTime.Now.AddDays(1);

            if (_contextData.Tokens.Any(e => e.username == username))
            {
                var getItem = _contextData.Tokens.FirstOrDefault(e => e.username == username);
                if (getItem != null) _contextData.Tokens.Remove(getItem); // xóa token cũ
            }



            _contextData.Tokens.Add(obj);
            await _contextData.SaveChangesAsync();

            return token;
        }

        public string GetToken(HttpRequest request)
        {
            if (request.Headers.TryGetValue("token", out var tokenValue))
            {
                return tokenValue.ToString();
            }
            return null;
        }

        public bool CheckTheExpirationDateOfTheToken(HttpRequest request)
        {

            string token = GetToken(request);
            string username = GetUsername(request);
            if (username is not null)
            {
                TOKEN obj = _contextData.Tokens.FirstOrDefault(x => x.Token == token && x.username == username);
                if (obj != null)
                {
                    TokenService tokenService = new TokenService();

                    if (tokenService.IsTokenExpired(token))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public string GetUsername(HttpRequest request)
        {
            string token = GetToken(request);
            TokenService tokenService = new TokenService();
            if (tokenService.IsTokenExpired(token))
            {
                ClaimsPrincipal claimsPrincipal = tokenService.GetClaimsFromToken(token);

                return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            else
            {
                return null;
            }
        }

        public dynamic GetUsernameByToken(string token)
        {
            TokenService tokenService = new TokenService();
            if (tokenService.IsTokenExpired(token))
            {
                return tokenService.GetClaimsFromToken(token);
            }
            else
            {
                return null;
            }
        }

    }
}
