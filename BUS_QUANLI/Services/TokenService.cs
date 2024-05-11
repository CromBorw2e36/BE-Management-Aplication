using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace quan_li_app.Services
{
    public class TokenService
    {
        private const string SecretKey = "PHAN_PHEM_QUAN_LI_123"; // Khóa bí mật để tạo token
        private readonly SymmetricSecurityKey _securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF32.GetBytes(SecretKey));
        private int _Time = 24;

        public TokenService() { }

        public string GenerateToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new[]
            {
            //new Claim(ClaimTypes.NameIdentifier, userId), // Thêm các thông tin bạn muốn lưu trong token
                 new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(_Time), // Thời gian hết hạn của token
                SigningCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal GetClaimsFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _securityKey,
                    ValidateIssuer = false, // Có thể thay đổi tùy theo cấu hình của bạn
                    ValidateAudience = false, // Có thể thay đổi tùy theo cấu hình của bạn
                    ValidateLifetime = false // Không kiểm tra thời gian hết hạn trong trường hợp cần lấy thông tin ngay cả khi token đã hết hạn
                };

                // Giải mã token và lấy thông tin từ các claims
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

                return claimsPrincipal as ClaimsPrincipal;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine(ex.Message);
                return new ClaimsPrincipal();
            }
        }


        // true là còn hạn
        public bool IsTokenExpired(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _securityKey,
                    ValidateIssuer = false, // Có thể thay đổi tùy theo cấu hình của bạn
                    ValidateAudience = false, // Có thể thay đổi tùy theo cấu hình của bạn
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero // Đảm bảo không có khoảng thời gian để đối phó với độ chệch thời gian
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var expirationTime = jwtToken.ValidTo; // Thời gian hết hạn của token

                return expirationTime > DateTime.UtcNow; // Kiểm tra xem token đã hết hạn chưa
            }
            catch (Exception)
            {
                return false; // Nếu có lỗi hoặc token không hợp lệ, giả định rằng nó đã hết hạn
            }
        }

    }
}
