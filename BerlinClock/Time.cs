using System;

namespace BerlinClock
{
    public class Time : ITime
    {
        public int Hours { get; }
        public int Minutes { get; }
        public int Seconds { get; }

        public Time(int hours, int minutes, int seconds)
        {
            ValidateValue(hours, 24, nameof(hours));
            ValidateValue(minutes, 59, nameof(minutes));
            ValidateValue(seconds, 59, nameof(seconds));

            if (hours == 24 && (minutes > 0 || seconds > 0))
                throw new ArgumentOutOfRangeException(nameof(hours), "When using 24 as value for hours the minutes and seconds should be set to 0.");

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        private static void ValidateValue(int value, int maxValue, string parameterName)
        {
            if (string.IsNullOrEmpty(parameterName))
                throw new ArgumentNullException(nameof(parameterName), "Parameter name should not be empty or null.");

            if (maxValue <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxValue), "Max value should be greater than 0.");

            if (value < 0 || value > maxValue)
                throw new ArgumentOutOfRangeException(parameterName, $"Number of {parameterName} should be in range: [0-{maxValue}]. Received value was: {value}");
        }
    }
}
