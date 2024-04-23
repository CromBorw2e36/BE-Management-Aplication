using DAL_QUANLI.Models.CustomModel;
using Microsoft.AspNetCore.Http;
using quan_li_app.Models;
using quan_li_app.Models.DataDB;
using quan_li_app.Services;
using System.Security.Claims;

namespace quan_li_app.Helpers
{
    public class TokenHelper
    {
        private readonly DataContext _contextData;
        private readonly CommonHelpers commonHelpers;
        public TokenHelper()
        {
            _contextData = new DataContext();
            commonHelpers = new CommonHelpers();
        }

        public async Task<string> GenTokenLogin(TOKEN acc, string username)
        {
            if (acc == null)
            {
                acc = new TOKEN();
            }
            TokenService tokenService = new TokenService();
            string token = tokenService.GenerateToken(username);

            TOKEN obj = new TOKEN
            {
                id = commonHelpers.GenerateRowID("Token", ""),
                Token = token,
                username = username ?? null,
                date = DateTime.Now,
                endDate = DateTime.Now.AddHours(4),
                ip_address = null,// IP address
                type_device = acc.type_device,
                os = acc.os,
                browser = acc.browser,
                device = acc.device,
                os_version = acc.os_version,
                browser_version = acc.browser_version,
                is_mobile = acc.is_mobile,
                is_tablet = acc.is_tablet,
                is_desktop = acc.is_desktop,
                is_ios = acc.is_ios,
                is_android = acc.is_android,
                orientation = acc.orientation,
                latitude = acc.latitude,
                longitude = acc.longitude,
                last_date_connect = null,
                is_connecting = false
            };


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

        public async Task<string> GenTokenLogin(AccountClientLoginParamsModel acc)
        {
            TokenService tokenService = new TokenService();
            string token = tokenService.GenerateToken(acc.account);
            //string getID = _contextData.Database.SqlQuery("EXEC GenerateCodePrimaryKey @pCompanyCode, @pTableName", new SqlParameter("pCompanyCode", ""), new SqlParameter("pTableName", "Token")).FirstOrDefault();
            //var getID = _contextData.Database.SqlQueryRaw<string>("EXEC GenerateCodePrimaryKey @pCompanyCode, @pTableName", new SqlParameter("@pCompanyCode", ""), new SqlParameter("@pTableName", "Token")).FirstOrDefault();


            TOKEN obj = new TOKEN
            {
                id = commonHelpers.GenerateRowID("Token", acc.companyCode!),
                Token = token,
                username = acc.account ?? null,
                date = DateTime.Now,
                endDate = DateTime.Now.AddHours(4),
                ip_address = acc.ip_address,// IP address
                type_device = acc.type_device,
                os = acc.os,
                browser = acc.browser,
                device = acc.device,
                os_version = acc.os_version,
                browser_version = acc.browser_version,
                is_mobile = acc.is_mobile,
                is_tablet = acc.is_tablet,
                is_desktop = acc.is_desktop,
                is_ios = acc.is_ios,
                is_android = acc.is_android,
                orientation = acc.orientation,
                latitude = acc.latitude,
                longitude = acc.longitude,
                last_date_connect = DateTime.Now,
                is_connecting = true
            };


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
            return "";
        }

        public bool CheckTheExpirationDateOfTheToken(HttpRequest request)
        {

            string token = GetToken(request);
            string username = GetUsername(request);
            if (username is not null)
            {
                TOKEN obj = _contextData.Tokens.Where(x => x.Token == token && x.username == username).FirstOrDefault()!;
                if (obj != null)
                {

                    TokenService tokenService = new TokenService();

                    if (tokenService.IsTokenExpired(token))
                    {
                        try
                        {
                            obj.last_date_connect = DateTime.Now;
                            obj.is_connecting = true;
                            _contextData.SaveChangesAsync().Wait();
                        }
                        catch
                        {
                            return true;
                        }
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

                return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value!;
            }
            else
            {
                return "";
            }
        }

        public static string GetUsername_2(HttpRequest request)
        {

            string token = "";
            if (request.Headers.TryGetValue("token", out var tokenValue))
            {
                token = tokenValue.ToString();
            }
            token = "";

            TokenService tokenService = new TokenService();
            if (tokenService.IsTokenExpired(token))
            {
                ClaimsPrincipal claimsPrincipal = tokenService.GetClaimsFromToken(token);

                return claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value!;
            }
            else
            {
                return "";
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
                return "";
            }
        }

    }
}
