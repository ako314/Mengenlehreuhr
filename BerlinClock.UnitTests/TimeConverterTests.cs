using NSubstitute;
using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    public class TimeConverterTests
    {
        private ITimeConverter timeConverter;
        private const string TimeAsString = "17:24:31";
        private const string ExpectedOutput = @"O
RRRO
RROO
YYRYOOOOOOO
YYYY";

        [SetUp]
        public void Setup()
        {
            var timeParser = Substitute.For<ITimeParser>();
            timeParser.Parse(Arg.Any<string>())
                .Returns(new Time(17, 24, 31));

            var berlinClockBuilder = Substitute.For<IBerlinClockBuilder>();
            berlinClockBuilder.Build(Arg.Any<ITime>()).Returns(ExpectedOutput);

            timeConverter = new TimeConverter(timeParser, berlinClockBuilder);
        }

        [Test]
        public void ShouldConvert()
        {
            Assert.That(timeConverter.ConvertTime(TimeAsString), Is.EqualTo(ExpectedOutput));
        }
    }
}