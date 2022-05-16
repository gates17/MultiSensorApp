namespace MultiSensorApi.Helpers
{
    public static class Validations
    {
        /// <summary>
        /// Converts date and time string to DateTime
        /// </summary>
        /// <param name="dateString"></param>
        /// <param name="timeString"></param>
        /// <returns></returns>
        public static DateTime StringToDateTime(string dateString, string timeString)
        {
            DateTime date = Convert.ToDateTime(dateString) + TimeSpan.Parse(timeString);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
            return date;
        }

        
        /// <summary>
        /// Converts date string to date with time set to 00:00:00
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static DateTime StringToDateTime(string dateString)
        {
            DateTime date = Convert.ToDateTime(dateString);
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
            return date.Date;
        }

        /// <summary>
        /// Converts time string to Timespan with date set to current day
        /// </summary>
        /// <param name="timeString"></param>
        /// <returns></returns>
        public static DateTime StringToTime(string timeString)
        {
            DateTime date = DateTime.Today;
            date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
            TimeSpan time = TimeSpan.Parse(timeString);
            date.Add(time);
            date += time;
            return date;
        }

    }
}
