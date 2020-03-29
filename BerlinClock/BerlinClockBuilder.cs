using System.Text;

namespace BerlinClock
{
    //this can be implemented in many ways
    //this is a simple solution but I don't want to over-engineer it
    public class BerlinClockBuilder : IBerlinClockBuilder
    {
        private const string HoursPattern = "RRRR";
        private const string MinutesChunksPattern = "YYRYYRYYRYY";
        private const string MinutesReminderPattern = "YYYY";
        private const char SwitchedOnRepresentation = 'Y';
        private const char SwitchedOffRepresentation = 'O';

        public string Build(ITime time)
        {
            var builder = new StringBuilder();

            builder.Append(time.Seconds % 2 == 0 ? SwitchedOnRepresentation : SwitchedOffRepresentation);
            builder.AppendLine();
            builder.AppendLine(BuildSingleValue(time.Hours / 5, HoursPattern));
            builder.AppendLine(BuildSingleValue(time.Hours % 5, HoursPattern));
            builder.AppendLine(BuildSingleValue(time.Minutes / 5, MinutesChunksPattern));
            builder.Append(BuildSingleValue(time.Minutes % 5, MinutesReminderPattern));

            return builder.ToString();
        }

        private static string BuildSingleValue(int value, string pattern)
        {
            return pattern.Substring(0, value)
                .PadRight(pattern.Length, SwitchedOffRepresentation);
        }
    }
}
