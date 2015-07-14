namespace Common.Helpers.DateTime
{
    using System;

    public class DateHelper
    {
        public static DateTime ToUtc(DateTime value, string timeZoneId)
        {
            DateTime? returnValue = null;
            if (value.Kind != DateTimeKind.Utc)
            {
                TimeZoneInfo tzone;

                if (value.Kind != DateTimeKind.Local)
                {
                    tzone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                }
                else
                {
                    tzone = TimeZoneInfo.Local;
                }

                returnValue = TimeZoneInfo.ConvertTimeToUtc(value, tzone);
            }
            else
                returnValue = value;

            return returnValue.Value;
        }

        public static DateTime UtcToTimeZone(DateTime value, string timeZoneId)
        {
            var tzone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var returnValue = TimeZoneInfo.ConvertTime(value, TimeZoneInfo.Utc, tzone);
            return returnValue;
        }
    }
}
