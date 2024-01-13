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
            obj.endDate = DateTime.Now.AddHours(4);

            //if (_contextData.Tokens.Any(e => e.username == username))
            //{
                //List<TOKEN> getItem = _contextData.Tokens.Where(e => e.username == username && e.endDate < DateTime.Now).ToList();
                //if(getItem.Count > 0) _contextData.Tokens.RemoveRange(getItem); // xóa token het han
                /*
                 * Sau  này kiểm tra TOKEN nào hết hạn thì xóa, vì người dùng có thể đăng nhập từ nhiều thiết bị nên 
                 * sẽ lấy vị trí, thiết bị sử dụng, địa chỉ IP của người dùng để lưu
                 */
            //}



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
