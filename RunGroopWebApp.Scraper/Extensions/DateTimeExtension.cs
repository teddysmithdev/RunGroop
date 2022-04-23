using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunGroopWebApp.Scraper.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime? ToDate(this string dateTimeStr, params string[] dateFmt)
        {
            // example: var dt = "2011-03-21 13:26".ToDate(new string[]{"yyyy-MM-dd HH:mm", 
            //                                                  "M/d/yyyy h:mm:ss tt"});
            // or simpler: 
            // var dt = "2011-03-21 13:26".ToDate("yyyy-MM-dd HH:mm", "M/d/yyyy h:mm:ss tt");
            const DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces;
            if (dateFmt == null)
            {
                var dateInfo = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                dateFmt = dateInfo.GetAllDateTimePatterns();
            }
            var result = DateTime.TryParseExact(dateTimeStr, dateFmt, CultureInfo.InvariantCulture,
                           style, out var dt) ? dt : null as DateTime?;
            return result;
        }
    }
}
