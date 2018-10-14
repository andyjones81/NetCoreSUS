using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreSUS.Models
{
    public static class DateExtentions
    {
        public static DateTime LastMonth(this DateTime dt)
        {
            //What is the current month?

            if (dt.Month == 1)
            {
                //January

                //The last month will be December, but the previous year

                return new DateTime(dt.AddYears(-1).Year, 12, 01);
            }
            else
            {
                return new DateTime(dt.Year, dt.AddMonths(-1).Month, 01);
            }
        }

        public static DateTime GetLastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }
    }
}
