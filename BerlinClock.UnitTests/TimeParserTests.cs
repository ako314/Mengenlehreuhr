using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    public class TimeParserTests
    {
        private ITimeParser timeParser = new TimeParser();

        [SetUp]
        public void Setup()
        {
            timeParser = new TimeParser();
        }

        [Test]
        public void ShouldThrowExceptionWhenTimeNull()
        {
            Assert.Throws<ArgumentNullException>(() => { timeParser.Parse(null); });
        }

        [Test]
        public void ShouldThrowExceptionWhenTimeEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => { timeParser.Parse(string.Empty); });
        }

        [TestCaseSource(nameof(InvalidTimeValues))]
        public void ShouldThrowExceptionWhenIncorrectFormat(string timeAsString)
        {
            Assert.Throws<ArgumentException>(() => { timeParser.Parse(timeAsString); });
        }

        private static IEnumerable<string> InvalidTimeValues()
        {
            yield return "aa:bb:cc";
            yield return "aa:00:00";
            yield return "00:bb:00";
            yield return "00:00:cc";
            yield return "0";
            yield return "25:00:00";
            yield return "00:60:00";
            yield return "00:00:60";
            yield return "000000";
            yield return "-1:00:00";
            yield return "00:-1:00";
            yield return "00:00:-1";
            yield return "0:0:0";
            yield return "00:0:00";
            yield return "00:00:0";
        }

        [TestCaseSource(nameof(CorrectTimeValues))]
        public void ShouldParse(string timeAsString, int hours, int minutes, int seconds)
        {
            var time = timeParser.Parse(timeAsString);
            Assert.That(time.Hours , Is.EqualTo(hours));
            Assert.That(time.Minutes, Is.EqualTo(minutes));
            Assert.That(time.Seconds, Is.EqualTo(seconds));
        }

        private static IEnumerable<object[]> CorrectTimeValues()
        {
            yield return new object[] { "00:00:00", 0, 0, 0 };
            yield return new object[] { "24:00:00", 24, 0, 0 };
            yield return new object[] { "01:02:03", 1, 2, 3 };
            yield return new object[] { "23:59:59", 23, 59, 59 };
        }
    }
}
