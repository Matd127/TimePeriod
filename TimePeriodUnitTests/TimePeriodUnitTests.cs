using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTimePeriod;

namespace TimePeriodUnitTests
{
    [TestClass]
    public class TimePeriodUnitTests
    {
        #region constructors

        [TestMethod, TestCategory("Constructors")]
        [DataRow(8, 2, 55, 28975)]
        [DataRow(0, 9, 4, 544)]
        [DataRow(1, 5, 58, 3958)]
        public void Constructor_WithThreeParams(int hours, int minutes, int seconds, long expected)
        {
            TimePeriod tp = new(hours, minutes, seconds);
            Assert.AreEqual(tp.PeriodOfTime, expected);
        }

        [TestMethod, TestCategory("Constructors")]
        [DataRow(1, 59, 7140)]
        [DataRow(0, 43, 2580)]
        [DataRow(3, 2, 10920)]
        public void Constructor_WithTwoParams(int hours, int minutes, long expected)
        {
           TimePeriod tp = new(hours, minutes);
           Assert.AreEqual(tp.PeriodOfTime, expected);

        }

        [TestMethod, TestCategory("Constructors")]
        [DataRow(9, 9)]
        [DataRow(9, 9)]
        [DataRow(9, 9)]
        public void Constructor_WithOneParam(int seconds, long expected)
        {
            TimePeriod tp = new(seconds);
            Assert.AreEqual(tp.PeriodOfTime, expected);

        }

        [TestMethod, TestCategory("Constructors")]
        [DataRow("1:1:1", 3661)]
        [DataRow("9:9:7", 32947)]
        [DataRow("1:2:3", 3723)]
        public void Constructor_StringParams(string timeperiod, long expected)
        {
            TimePeriod tp = new(timeperiod);
            Assert.AreEqual(tp.PeriodOfTime, expected);

        }

        [TestMethod, TestCategory("Constructors")]
        public void Constructor_WithTwoTimeParams()
        {

            Time t1 = new Time(10, 10, 20);
            Time t2 = new Time(20, 20, 0);
            TimePeriod t = new TimePeriod(t2, t1);

            Assert.AreEqual(t.ToString(), "10:09:40");

        }

        [TestMethod, TestCategory("Constructors")]
        [DataRow(-1, -2, -3)]
        [DataRow(0,0,-5)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithThreeParamsThrowsArgumentException(int hours, int minutes, int seconds)
        {
            TimePeriod tp = new(hours, minutes, seconds);
        }

        #endregion


        #region ToString
        [TestMethod, TestCategory("ToString")]
        [DataRow(1, 1, 1, "01:01:01")]
        [DataRow(0, 0, 0, "00:00:00")]
        [DataRow(17, 0, 5, "17:00:05")]
        public void ToString_Format(int hours, int minutes, int seconds, string expectedString)
        {
            TimePeriod t = new TimePeriod(hours, minutes, seconds);

            Assert.AreEqual(t.ToString(), expectedString);
        }

        #endregion

        #region Equals

        [TestMethod, TestCategory("Equals")]
        public void Equals_SameTime_True()
        {
            TimePeriod t1 = new TimePeriod(10, 53, 22);
            TimePeriod t2 = new TimePeriod(10, 53, 22);

            Assert.AreEqual(t1.Equals(t2), true);
        }

        [TestMethod, TestCategory("Equals")]
        public void Equals_OtherTime_False()
        {
            TimePeriod t1 = new TimePeriod(19, 32, 55);
            TimePeriod t2 = new TimePeriod(18, 32, 55);

            Assert.AreEqual(t1.Equals(t2), false);
        }

        [DataRow("23:53:59", "23:53:59", true)]
        [DataRow("12:34:31", "12:34:31", true)]
        [DataRow("1:1:1", "1:1:1", true)]
        [TestMethod, TestCategory("Equals")]
        public void Equals_SameTimeString_True(string str1, string str2, bool expectedResult)
        {
            TimePeriod t1 = new TimePeriod(str1);
            TimePeriod t2 = new TimePeriod(str2);
            bool result = t1.Equals(t2);

            Assert.AreEqual(expectedResult, result);
        }

        [DataRow("15:08:13", "15:18:13", false)]
        [DataRow("19:03:12", "9:03:12", false)]
        [DataRow("1:1:1", "0:0:0", false)]
        [TestMethod, TestCategory("Equals")]
        public void Equals_SameTimeString_False(string str1, string str2, bool expectedResult)
        {
            TimePeriod t1 = new TimePeriod(str1);
            TimePeriod t2 = new TimePeriod(str2);
            bool result = t1.Equals(t2);

            Assert.AreEqual(expectedResult, result);
        }


        #endregion

        #region Compare

        [DataTestMethod, TestCategory("Compare")]
        public void Compare_LeftPeriodIsGreaterReturnsTrue()
        {
            TimePeriod t1 = new TimePeriod(182, 11, 13);
            TimePeriod t2 = new TimePeriod(77, 10, 5);

            Assert.IsTrue(t1.CompareTo(t2) > 0);
        }


        [DataTestMethod, TestCategory("Compare")]
        public void Compare_RightPeriodIsGreaterReturnsTrue()
        {
            TimePeriod t1 = new TimePeriod(2, 2, 1);
            TimePeriod t2 = new TimePeriod(3, 15, 0);

            Assert.IsTrue(t1.CompareTo(t2) < 0);
        }

        #endregion

        #region Operators

        [DataRow(0, 0, 0, 0, 0, 0, true)]
        [DataRow(1, 0, 1, 0, 1, 0, false)]
        [TestMethod, TestCategory("Operators")]
        public void Operator_Equal_MathOperations(int h1, int m1, int s1, int h2, int m2, int s2, bool expected)
        {
            TimePeriod t1 = new TimePeriod(h1, m1, s1);
            TimePeriod t2 = new TimePeriod(h2, m2, s2);

            Assert.AreEqual(t1 == t2, expected);

        }

        [DataRow(2, 2, 3, 3, 2, 2, true)]
        [DataRow(157, 0, 2, 157, 0, 2, false)]
        [TestMethod, TestCategory("Operators")]
        public void Operator_NotEqual_MathOperations(int h1, int m1, int s1, int h2, int m2, int s2, bool expected)
        {
            TimePeriod t1 = new TimePeriod(h1, m1, s1);
            TimePeriod t2 = new TimePeriod(h2, m2, s2);

            Assert.AreEqual(t1 != t2, expected);

        }

        [DataRow(3, 0, 0, 5, 12, 0, true)]
        [DataRow(744, 1, 1, 0, 25, 45, false)]
        [TestMethod, TestCategory("Operators")]
        public void Operator_SmallerThan_MathOperations(int h1, int m1, int s1, int h2, int m2, int s2, bool expected)
        {
            TimePeriod t1 = new TimePeriod(h1, m1, s1);
            TimePeriod t2 = new TimePeriod(h2, m2, s2);

            Assert.AreEqual(t1 < t2, expected);

        }

        [DataRow(23, 55, 17, 23, 1, 14, true)]
        [DataRow(0, 0, 1, 0, 0, 2, false)]
        [TestMethod, TestCategory("Operators")]
        public void Operator_BiggerThan_MathOperations(int h1, int m1, int s1, int h2, int m2, int s2, bool expected)
        {
            TimePeriod t1 = new TimePeriod(h1, m1, s1);
            TimePeriod t2 = new TimePeriod(h2, m2, s2);

            Assert.AreEqual(t1 > t2, expected);

        }

        [DataRow(6, 8, 10, 16, 10, 59, true)]
        [DataRow(11, 0, 0, 3, 25, 5, false)]
        [DataRow(5, 10, 15, 5, 10, 15, true)]
        [TestMethod, TestCategory("Operators")]
        public void Operator_SmallerOrEqual_MathOperations(int h1, int m1, int s1, int h2, int m2, int s2, bool expected)
        {
            TimePeriod t1 = new TimePeriod(h1, m1, s1);
            TimePeriod t2 = new TimePeriod(h2, m2, s2);

            Assert.AreEqual(t1 <= t2, expected);

        }

        [DataRow(7, 15, 10, 6, 15, 7, true)]
        [DataRow(10, 0, 0, 10, 7, 0, false)]
        [DataRow(6, 6, 6, 6, 6, 6, true)]
        [TestMethod, TestCategory("Operators")]
        public void Operator_BiggerOrEqual_MathOperations(int h1, int m1, int s1, int h2, int m2, int s2, bool expected)
        {
            TimePeriod t1 = new TimePeriod(h1, m1, s1);
            TimePeriod t2 = new TimePeriod(h2, m2, s2);

            Assert.AreEqual(t1 >= t2, expected);

        }

        [TestMethod, TestCategory("Operators")]
        public void Operator_Plus_MathOperations()
        {
            TimePeriod t1 = new TimePeriod(1, 10, 15);
            TimePeriod t2 = new TimePeriod(1, 2, 1);

            var expected = new TimePeriod(2, 12, 16);
            Assert.AreEqual(expected, t1+t2);
        }


        [TestMethod, TestCategory("Operators")]
        public void Operator_Minus_MathOperations()
        {
            TimePeriod t1 = new TimePeriod(5, 3, 7);
            TimePeriod t2 = new TimePeriod(2, 2, 2);

            var expected = new TimePeriod(3, 1, 5);
            Assert.AreEqual(expected, t1 - t2);
        }

        [TestMethod, TestCategory("Operators")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Operator_Minus_MathOperationsReturnsArgumentOutOfRangeException()
        {
            TimePeriod t1 = new TimePeriod(134, 2, 2);
            TimePeriod t2 = new TimePeriod(199, 2, 2);

            var expected = new TimePeriod(3, 1, 5);
            Assert.AreEqual(expected, t1 - t2);
        }

        #endregion
    }

}
