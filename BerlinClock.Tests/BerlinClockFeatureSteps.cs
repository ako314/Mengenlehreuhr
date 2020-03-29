using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BerlinClock.Tests
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private readonly ITimeConverter berlinClock = new TimeConverter(new TimeParser(), new BerlinClockBuilder());
        private string time;

        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            this.time = time;
        }

        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(berlinClock.ConvertTime(time), theExpectedBerlinClockOutput);
        }

    }
}