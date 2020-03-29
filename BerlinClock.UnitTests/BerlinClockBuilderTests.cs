using System.Collections.Generic;
using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    public class BerlinClockBuilderTests
    {
        private IBerlinClockBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new BerlinClockBuilder();
        }

        [TestCaseSource(nameof(TimeValues))]
        public void ShouldBuildCorrectly(ITime time, string timeRepresentation)
        {
            Assert.That(builder.Build(time), Is.EqualTo(timeRepresentation));
        }

        private static IEnumerable<object[]> TimeValues()
        {
            yield return new object[] {new Time(0, 0, 0), @"Y
OOOO
OOOO
OOOOOOOOOOO
OOOO" };

            yield return new object[] { new Time(24, 0, 0), @"Y
RRRR
RRRR
OOOOOOOOOOO
OOOO" };

            yield return new object[] { new Time(23, 59, 59), @"O
RRRR
RRRO
YYRYYRYYRYY
YYYY" };
        }
    }

}
