using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SohaService.Core.Convertor
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }

        public static DateTime ToMiladi(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,dateTime.Hour,dateTime.Minute,dateTime.Second,dateTime.Millisecond, new System.Globalization.PersianCalendar());
        }

        public static DateTime AddTimeToDate(this DateTime value, double houre, double minute)
        {
            return value.AddHours(houre).AddMinutes(minute);
        }
    }

}
