using Microsoft.AspNetCore.Http;
using System.Net;

namespace quan_li_app.Helpers
{
    public class CommonHelpers
    {
        public string DateCalculatingYearMonthDate(DateTime pDate1, DateTime pDate2, string language = "vi")
        {
            TimeSpan difference = pDate1 - pDate2;
            int years = (int)(difference.Days / 365.25);
            int months = (int)((difference.Days % 365.25) / 30.4375);
            int days = (int)((difference.Days % 365.25) % 30.4375);
            if (language == "vi")
            {
                return $"{years} năm, {months} tháng, {days} ngày";
            }
            else
            {
                return $"{years} years, {months} months, {days} days";
            }
        }

        public string GetClientIPAddressString(HttpContext httpConect)
        {
            var ipAddress = httpConect.Connection.RemoteIpAddress;
            var forwardedFor = httpConect.Request.Headers["X-Forwarded-For"];
            var realIp = httpConect.Request.Headers["X-Real-IP"];
            if (!string.IsNullOrEmpty(forwardedFor))
            {
                string[] ips = forwardedFor.ToString().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return ips.FirstOrDefault().ToString();
            }
            if (!string.IsNullOrEmpty(realIp))
            {
                if (IPAddress.TryParse(realIp.ToString(), out var parsedIPAddress))
                {
                    ipAddress = parsedIPAddress;
                }
            }
            return ipAddress.ToString();
        }

        public bool CheckInValidVariableTypeString(string data, bool checkEsle = false)
        {
            if (!checkEsle)
            {
                return data is null || data.Length == 0;
            }
            else
            {
                return data is not null || data.Length >= 0;
            }
        }

    }
}
