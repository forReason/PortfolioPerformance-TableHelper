using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioPerformance_TableHelper
{
    public class DateTimeHelper
    {
        public static SplitDateTime Split(DateTime input)
        {
            string date = input.ToString("yyyy/MM/dd");
            string time = input.ToString("HH:mm");
            return new SplitDateTime(date, time);
        }
    }
    public struct SplitDateTime
    {
        public SplitDateTime(string date, string time)
        {
            this.Date = date;
            this.Time = time;
        }
        public string Date { get; private set; }
        public string Time { get; private set; }
    }
}
