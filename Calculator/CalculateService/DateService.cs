using System;

namespace Calculator.CalculateService
{
    public class DateService
    {
        public static string DiffirenceDates(DateTime fromDate, DateTime toDate)
        {
            return (fromDate - toDate).ToString("%d");
        }

        public static string AddDates(DateTime date, int years, int months, int days)
        {
            return date.AddYears(years).AddMonths(months).AddDays(days).ToString("D");
        }

        public static string SubtractDates(DateTime date, int years, int months, int days)
        {
            return date.AddYears(-years).AddMonths(-months).AddDays(-days).ToString("D");
        }
    }
}
