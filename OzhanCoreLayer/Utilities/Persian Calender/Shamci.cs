using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanCoreLayer.Utilities.Persian_Calender
{
    public static class Shamci
    {
        public static string ToShamci(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value).ToString("0000") + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }
    }
}
