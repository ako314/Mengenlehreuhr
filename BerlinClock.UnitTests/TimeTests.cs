using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    public class TimeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource(nameof(InvalidTimeValues))]
        public void ShouldThrowExceptionWhenTimePartsAreOutOfRange(int hours, int minutes, int seconds)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var _ = new Time(hours, minutes, seconds);
            });
        }

        private static IEnumerable<object[]> InvalidTimeValues()
        {
            yield return new object[] { 25, 0, 0};
            yield return new object[] { -1, 0, 0 };
            yield return new object[] { 0, 60, 0 };
            yield return new object[] { 0, -1, 0 };
            yield return new object[] { 0, 0, 60 };
            yield return new object[] { 0, 0, -1 };
        }
    }
}
