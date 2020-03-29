using System;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    public class TimeParser : ITimeParser
    {
        private const string HoursGroup = "hours";
        private const string MinutesGroup = "minutes";
        private const string SecondsGroup = "seconds";

        private const string RegExPattern = "^(?<" + HoursGroup + ">[0-1]?[0-9]|2[0-4])" +
                                            ":(?<" + MinutesGroup + ">[0-5][0-9])" +
                                            ":(?<" + SecondsGroup + ">[0-5][0-9])$";

        private static readonly Regex RegularExpressionForTime = new Regex(RegExPattern);

        public ITime Parse(string time)
        {
            if (string.IsNullOrEmpty(time))
                throw new ArgumentNullException(nameof(time), "Time cannot be null or empty.");

            var regExMatch = RegularExpressionForTime.Match(time);

            if (!regExMatch.Success)
                throw new ArgumentException("Invalid time format. Expected format: HH:mm:ss", nameof(time));

            return new Time(
                int.Parse(regExMatch.Groups[HoursGroup].Value),
                int.Parse(regExMatch.Groups[MinutesGroup].Value),
                int.Parse(regExMatch.Groups[SecondsGroup].Value));
        }
    }
}
