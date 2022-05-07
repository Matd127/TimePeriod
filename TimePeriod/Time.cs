using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePeriod
{
    public struct Time
    {
        public static void CheckTime(byte? hours = null, byte? minutes = null, byte? seconds = null)
        {
            if (hours != null)
                if (hours > 23 || hours < 0)
                    throw new ArgumentException("Niepoprawna liczba godzin");

            if (minutes != null)
                if (minutes > 59 || minutes < 0)
                    throw new ArgumentException("Niepoprawna liczba minut");

            if (seconds != null)
                if (seconds > 59 || seconds < 0)
                    throw new ArgumentException("Niepoprawna liczba sekund");

        }
        private readonly byte _hours;
        private readonly byte _minutes;
        private readonly byte _seconds;

        public byte Hours => _hours;
        public byte Minutes => _minutes;
        public byte Seconds => _seconds;
        
        public Time(byte hours, byte minutes, byte seconds) {

            CheckTime(hours, minutes, seconds);

            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
        }

        public Time(byte hours, byte minutes){

            CheckTime(hours, minutes);
            _hours = hours;
            _minutes = minutes;
            _seconds = 0;
        }

        public Time(byte hours){
            CheckTime(hours);
            _hours = hours;
            _minutes = 0;
            _seconds = 0;
        }
    }
}
