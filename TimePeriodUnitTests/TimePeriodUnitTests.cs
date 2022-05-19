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

        //[TestMethod, TestCategory("Constructors")]
        //[DataRow(6, 0,2)]
        //public void Constructor_WithTwoTimeParams(Time t1, Time t2, long expected)
        //{

        //    t1 = new Time(13, 15, 12);
        //    t2 = new Time(7, 15, 10);
        //    var result = t1 - t2;
        //    Assert.AreEqual(result, expected);

        //}

        [TestMethod, TestCategory("Constructors")]
        [DataRow(-1, -2, -3)]
        [DataRow(0,0,-5)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithThreeParamsThrowsArgumentException(int hours, int minutes, int seconds)
        {
            TimePeriod tp = new(hours, minutes, seconds);
        }

        #endregion



    }

}
