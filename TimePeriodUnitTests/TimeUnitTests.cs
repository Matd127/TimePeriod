using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimePeriod;

namespace TimePeriodUnitTests
{
    [TestClass]
    public class TimeUnitTests
    {
        #region constructors
        private void AssertTime(Time t, byte expectedHours, byte expectedMinutes, byte expectedSeconds)
        {
            Assert.AreEqual(t.Hours, expectedHours);
            Assert.AreEqual(t.Minutes, expectedMinutes);
            Assert.AreEqual(t.Seconds, expectedSeconds);
        }

        [DataRow((byte)12, (byte)27, (byte)55)]
        [DataRow((byte)23, (byte)59, (byte)4)]
        [DataRow((byte)1, (byte)5, (byte)58)]
        [TestMethod, TestCategory("Constructors")]
        public void Constructor_3Params(byte hours, byte minutes, byte seconds) 
        {
            Time t = new Time(hours, minutes, seconds);

            AssertTime(t, hours, minutes, seconds);
        }



        #endregion
    }
}
