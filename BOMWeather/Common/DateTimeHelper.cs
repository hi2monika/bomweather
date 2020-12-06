using System;
using System.Globalization;
using System.Linq;

namespace BOMWeather.Common
{
    public static class DateTimeHelper
    {
        public static bool IsCurrentMonth(string month, string year)
        {
            return (DateTime.Now.Month == Convert.ToInt16(month)) && DateTime.Now.Year == Convert.ToInt16(year);
        }

        public static string GetMonthName(int month)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        }
    }
}