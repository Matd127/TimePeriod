using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePeriod
{
    public struct TimePeriod
    {
        public static void CheckTime(byte? hours = null, byte? minutes = null, byte? seconds = null)
        {
            if (hours != null)
                if (hours < 0)
                    throw new ArgumentException("Niepoprawna liczba godzin");

            if (minutes != null)
                if (minutes < 0)
                    throw new ArgumentException("Niepoprawna liczba minut");

            if (seconds != null)
                if (seconds < 0)
                    throw new ArgumentException("Niepoprawna liczba sekund");

        }
        private long PeriodOfTime { get; }

        public TimePeriod(byte hours, byte minutes, byte seconds) {
            CheckTime(hours, minutes, seconds);
            PeriodOfTime = (hours * 3600) + (minutes * 60) + seconds;
        }
    }
}
