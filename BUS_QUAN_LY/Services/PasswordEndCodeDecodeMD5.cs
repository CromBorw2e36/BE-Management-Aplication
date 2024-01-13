using System.Security.Cryptography;
using System.Text;

namespace quan_li_app.Services
{
    public class PasswordEndCodeDecodeMD5
    {


        public PasswordEndCodeDecodeMD5()
        {

        }

        public string EndCodeMd5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển đổi byte array thành chuỗi hex
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
