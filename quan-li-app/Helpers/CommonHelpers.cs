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

    }
}
