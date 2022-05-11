using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TimePeriod;

namespace TimePeriodUnitTests
{
    [TestClass]
    public class TimeUnitTests
    {
        #region Constructors
        private void AssertTime(Time t, byte expectedHours, byte expectedMinutes, byte expectedSeconds)
        {
            Assert.AreEqual(t.Hours, expectedHours);
            Assert.AreEqual(t.Minutes, expectedMinutes);
            Assert.AreEqual(t.Seconds, expectedSeconds);
        }

        [TestMethod, TestCategory("Constructors")]
        [DataRow((byte)12, (byte)27, (byte)55)]
        [DataRow((byte)23, (byte)59, (byte)4)]
        [DataRow((byte)1, (byte)5, (byte)58)] 
        public void Constructor_3Params(byte hours, byte minutes, byte seconds) 
        {
            Time t = new(hours, minutes, seconds);
            AssertTime(t, hours, minutes, seconds);
        }
        [TestMethod, TestCategory("Constructors")]
        [DataRow((byte)9, (byte)59)]
        [DataRow((byte)18, (byte)43)]
        [DataRow((byte)3, (byte)2)]      
        public void Constructor_2Params(byte hours, byte minutes)
        {
            Time t = new(hours, minutes);
            AssertTime(t, hours, minutes, 0);
        }

        [TestMethod, TestCategory("Constructors")]
        [DataRow((byte)9)]
        [DataRow((byte)9)]
        [DataRow((byte)9)]
        public void Constructor_1Param(byte hours)
        {
            Time t = new(hours);

            Assert.AreEqual(hours, t.Hours);
            Assert.AreEqual(0, t.Minutes);
            Assert.AreEqual(0, t.Seconds);

        }

        [TestMethod, TestCategory("Constructors")]
        public void Constructor_NoParams()
        {
            Time t = new();
            Assert.AreEqual(0, t.Hours);
            Assert.AreEqual(0, t.Minutes);
            Assert.AreEqual(0, t.Seconds);
        }

        [TestMethod, TestCategory("Constructors")]
        [DataRow("1:49:45")]
        [DataRow("23:19")]
        [DataRow("11")]
        public void Constructor_StringParams(string time)
        {
            Time t = new(time);
        }

        [TestMethod, TestCategory("Constructors")]
        [DataRow(23, 13, 99)]
        [DataRow(-1, -13, 25)]
        [DataRow(27, 61, 63)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Invalid3Params_ThrowsArgumentOutOfRangeException(int hours, int minutes, int seconds)
        {
            Time t = new Time((byte)hours, (byte)minutes, (byte)seconds);
        }

        [TestMethod, TestCategory("Constructors")]
        [DataRow(-1, 15)]
        [DataRow(16, 99)]
        [DataRow(100, 97)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Invalid2Params_ThrowsArgumentOutOfRangeException(int hours, int minutes)
        {
            Time t = new Time((byte)hours, (byte)minutes);
        }

        [TestMethod, TestCategory("Constructors")]
        [DataRow(-5)]
        [DataRow(27)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Invalid1Param_ThrowsArgumentOutOfRangeException(int hours)
        {
            Time t = new Time((byte)hours);
        }

        [TestMethod, TestCategory("Constructors")]
        [DataRow("1:68:45")]
        [DataRow("55:28:05")]
        [DataRow("55:28:99")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_InvalidNonNegativeStringParams_ThrowsArgumentOutOfRangeException(string time)
        {
            Time t = new Time(time);
        }

        [TestMethod, TestCategory("Constructors")]
        [DataRow("-1:68:45")]
        [DataRow("55:-28:05")]
        [DataRow("55:28:-99")]
        [ExpectedException(typeof(OverflowException))]
        public void Constructor_InvalidNegativeStringParams_ThrowsOverflowException(string time)
        {
            Time t = new Time(time);
        }

        [TestMethod, TestCategory("Constructors")]
        [DataRow("-1;68:45")]
        [DataRow("zs:34:df")]
        [DataRow(":::")]
        [ExpectedException(typeof(FormatException))]
        public void Constructor_InvalidStringParams_ThrowsFormatException(string time)
        {
            Time t = new Time(time);
        }

        #endregion

        #region ToString
        [TestMethod, TestCategory("ToString")]
        [DataRow((byte)1, (byte)1, (byte)1, "01:01:01")]
        [DataRow((byte)0, (byte)0, (byte)0, "00:00:00")]
        [DataRow((byte)17, (byte)0, (byte)5, "17:00:05")]
        [DataRow((byte)9, (byte)50, (byte)59, "09:50:59")]
        [DataRow((byte)23, (byte)59, (byte)50, "23:59:50")]
        public void ToString_Format(byte hour, byte minute, byte second, string expectedString)
        {
            Time t = new Time(hour, minute, second);

            Assert.AreEqual(t.ToString(), expectedString);
        }

        #endregion

        #region Equals

        [TestMethod, TestCategory("Equals")]
        public void Equals_SameTime_True()
        {

        }

        #endregion

        #region Operators



        #endregion
    }
}
