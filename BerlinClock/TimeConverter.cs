namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly ITimeParser timeParser;
        private readonly IBerlinClockBuilder berlinClockBuilder;

        public TimeConverter(ITimeParser timeParser, IBerlinClockBuilder berlinClockBuilder)
        {
            this.timeParser = timeParser;
            this.berlinClockBuilder = berlinClockBuilder;
        }

        public string ConvertTime(string timeAsString)
        {
            var time = timeParser.Parse(timeAsString);
            return berlinClockBuilder.Build(time);
        }
    }
}