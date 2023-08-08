using System.Globalization;
namespace PortfolioPerformanceTableHelper
{
    /// <summary>
    /// Provides helper methods to split and merge date and time representations.
    /// </summary>
    public class DateTimeHelper
    {
        /// <summary>
        /// Splits a DateTime into its date and time components.
        /// </summary>
        /// <param name="input">The DateTime to split.</param>
        /// <returns>A SplitDateTime object containing the date and time components as strings.</returns>
        public static SplitDateTime Split(DateTime input)
        {
            string date = input.ToString("yyyy/MM/dd");
            string time = input.ToString("HH:mm:ss");
            return new SplitDateTime(date, time);
        }
        /// <summary>
        /// Merges a SplitDateTime into a single DateTime object.
        /// </summary>
        /// <param name="input">The SplitDateTime object containing date and time components.</param>
        /// <returns>A DateTime object created by merging the date and time components.</returns>
        public static DateTime Merge(SplitDateTime input)
        {
            return Merge(input.Date, input.Time);
        }
        /// <summary>
        /// Merges two strings into a single DateTime.
        /// </summary>
        /// <param name="date">The Date part of the DateTime</param>
        /// <param name="time">The Time part of the DateTime</param>
        /// <returns>A DateTime object created by merging the date and time strings.</returns>
        public static DateTime Merge(string date, string time)
        {
            if (string.IsNullOrEmpty(date) || string.IsNullOrEmpty(time))
            {
                throw new ArgumentNullException("Input strings should not be null or empty.");
            }

            // Use the provided formats for parsing
            DateTime datePart = DateTime.ParseExact(date, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            DateTime timePart = DateTime.ParseExact(time, "HH:mm:ss", CultureInfo.InvariantCulture);

            return new DateTime(datePart.Year, datePart.Month, datePart.Day, timePart.Hour, timePart.Minute, timePart.Second);
        }
    }
    /// <summary>
    /// Represents split date and time components.
    /// </summary>
    public struct SplitDateTime
    {
        /// <summary>
        /// Initializes a new instance of the SplitDateTime structure.
        /// </summary>
        /// <param name="date">The date component.</param>
        /// <param name="time">The time component.</param>
        public SplitDateTime(string date, string time)
        {
            this.Date = date;
            this.Time = time;
        }

        /// <summary>
        /// Gets the date component.
        /// </summary>
        public string Date { get; private set; }

        /// <summary>
        /// Gets the time component.
        /// </summary>
        public string Time { get; private set; }
    }
}
