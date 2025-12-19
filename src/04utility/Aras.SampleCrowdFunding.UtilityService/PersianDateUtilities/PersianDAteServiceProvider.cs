using System.Globalization;

namespace Aras.SampleCrowdFunding.UtilityService.PersianDateUtilities
{
    public static class PersianDAteServiceProvider
    {
        public static DateTime? ToUtcDateTimeWithoutTimeCustomizedForBirthDate(this string persianDate)
        {

            if (persianDate == null || persianDate=="null")
                return null;

            string[] strArray = persianDate.Split('/');
            int year = int.Parse(strArray[0]);
            int month = int.Parse(strArray[1]);
            int day = int.Parse(strArray[2]);

            PersianCalendar persianCalendar = new PersianCalendar();
            if (!persianCalendar.IsLeapYear(year) && month == 12 && day == 30)
            {
                day = 29;
            }
            DateTime localDateTime = persianCalendar.ToDateTime(year, month, day, 18, 0, 0, 0);

            DateTime utcDateTime = TimeZoneInfo.ConvertTimeToUtc(localDateTime);

            return utcDateTime;
        }
    }
}
