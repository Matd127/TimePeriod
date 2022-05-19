using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TimeTimePeriod;

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
        public void ToString_Format(byte hours, byte minutes, byte seconds, string expectedString)
        {
            Time t = new Time(hours, minutes, seconds);

            Assert.AreEqual(t.ToString(), expectedString);
        }

        #endregion

        #region Equals

        [TestMethod, TestCategory("Equals")]
        public void Equals_SameTime_True()
        {
            Time t1 = new Time(10, 53, 22);
            Time t2 = new Time(10, 53, 22);

            Assert.AreEqual(t1.Equals(t2), true);
        }

        [TestMethod, TestCategory("Equals")]
        public void Equals_OtherTime_False()
        {
            Time t1 = new Time(19, 32, 55);
            Time t2 = new Time(18, 32, 55);

            Assert.AreEqual(t1.Equals(t2), false);
        }

        [DataRow("23:53:59", "23:53:59", true)]
        [DataRow("12:34:31", "12:34:31", true)]
        [DataRow("1:1:1", "1:1:1", true)]
        [TestMethod, TestCategory("Equals")]
        public void Equals_SameTimeString_True(string str1, string str2, bool expectedResult)
        {
            Time t1 = new Time(str1);
            Time t2 = new Time(str2);
            bool result = t1.Equals(t2);

            Assert.AreEqual(expectedResult, result);
        }

        [DataRow("15:08:13", "15:18:13", false)]
        [DataRow("19:03:12", "9:03:12", false)]
        [DataRow("1:1:1", "0:0:0", false)]
        [TestMethod, TestCategory("Equals")]
        public void Equals_SameTimeString_False(string str1, string str2, bool expectedResult)
        {
            Time t1 = new Time(str1);
            Time t2 = new Time(str2);
            bool result = t1.Equals(t2);

            Assert.AreEqual(expectedResult, result);
        }

        #endregion

        #region Operators

        [DataRow((byte)12, (byte)13, (byte)15,
           (byte)12, (byte)13, (byte)15, true)]
        [DataRow((byte)17, (byte)13, (byte)9,
           (byte)17, (byte)23, (byte)9, false)]
        [TestMethod, TestCategory("Operators")]
        public void Operator_Equal_MathOperations(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2, bool expected)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            Assert.AreEqual(t1 == t2, expected);

        }

        [DataRow((byte)23, (byte)43, (byte)29,
            (byte)12, (byte)13, (byte)15, true)]
        [DataRow((byte)5, (byte)23, (byte)22,
            (byte)5, (byte)23, (byte)22, false)]
        [TestMethod, TestCategory("Operators")]
        public void Operator_NotEqual_MathOperations(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2, bool expected)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            Assert.AreEqual(t1 != t2, expected);

        }

        [DataRow((byte)12, (byte)15, (byte)33,
            (byte)12, (byte)28, (byte)15, true)]
        [DataRow((byte)22, (byte)21, (byte)43,
            (byte)19, (byte)13, (byte)5, false)]
        [TestMethod, TestCategory("Operators")]
        public void Operator_SmallerThan_MathOperations(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2, bool expected)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            Assert.AreEqual(t1 < t2, expected);

        }

        [DataRow((byte)23, (byte)55, (byte)17,
            (byte)23, (byte)1, (byte)14, true)]
        [DataRow((byte)0, (byte)0, (byte)11,
            (byte)1, (byte)9, (byte)15, false)]
        [TestMethod, TestCategory("Operators")]
        public void Operator_BiggerThan_MathOperations(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2, bool expected)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            Assert.AreEqual(t1 > t2, expected);

        }

        [DataRow((byte)11, (byte)13, (byte)22,
            (byte)12, (byte)23, (byte)11, true)]
        [DataRow((byte)23, (byte)0, (byte)0,
            (byte)19, (byte)33, (byte)5, false)]
        [DataRow((byte)16, (byte)30, (byte)0,
            (byte)16, (byte)30, (byte)0, true)]
        [TestMethod, TestCategory("Operators")]
        public void Operator_SmallerOrEqual_MathOperations(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2, bool expected)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            Assert.AreEqual(t1 <= t2, expected);

        }

        [DataRow((byte)7, (byte)15, (byte)10,
            (byte)6, (byte)15, (byte)7, true)]
        [DataRow((byte)12, (byte)0, (byte)0,
            (byte)19, (byte)43, (byte)15, false)]
        [DataRow((byte)14, (byte)46, (byte)59,
            (byte)14, (byte)46, (byte)59, true)]
        [TestMethod, TestCategory("Operators")]
        public void Operator_BiggerOrEqual_MathOperations(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2, bool expected)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            Assert.AreEqual(t1 >= t2, expected);

        }

        [DataRow((byte)7, (byte)15, (byte)10,
            (byte)6, (byte)15, (byte)7, "13:30:17")]
        [DataRow((byte)23, (byte)59, (byte)59,
            (byte)0, (byte)0, (byte)1, "00:00:00")]
        [DataRow((byte)0, (byte)0, (byte)0,
            (byte)0, (byte)0, (byte)1, "00:00:01")]
        [DataRow((byte)12, (byte)30, (byte)0,
            (byte)11, (byte)30, (byte)0, "00:00:00")]
        [TestMethod, TestCategory("Operators")]
        public void Operator_Plus_MathOperations(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2, string expected)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            Time sum = t1 + t2;

            Assert.AreEqual(expected, sum.ToString());

        }

        [DataRow((byte)15, (byte)35, (byte)10,
            (byte)5, (byte)15, (byte)10, "10:20:00")]
        [DataRow((byte)00, (byte)00, (byte)00,
            (byte)0, (byte)23, (byte)1, "23:36:59")]
        [DataRow((byte)1, (byte)00, (byte)00,
            (byte)2, (byte)0, (byte)0, "23:00:00")]
        [TestMethod, TestCategory("Operators")]
        public void Operator_Minus_MathOperations(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2, string expected)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);

            Time diff = t1 - t2;

            Assert.AreEqual(expected, diff.ToString());

        }

        #endregion
    }
}
