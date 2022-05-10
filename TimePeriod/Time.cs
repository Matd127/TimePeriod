using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePeriod
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        public static void CheckTime(byte? hours = null, byte? minutes = null, byte? seconds = null){
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

        //hh:mm:ss
        public Time(string time){
            string[] t = time.Split(":");
            byte[] tim = new byte[3];

            for (int i = 0; i < t.Length; i++){
                tim[i] = byte.Parse(t[i]);
            }
            CheckTime(tim[0], tim[1], tim[2]);
            
            _hours = tim[0];
            _minutes = tim[1];
            _seconds = tim[2];
        }

        public override string ToString() => $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";

        public bool Equals(Time other) => Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;

        public override bool Equals(object obj){
            if (obj is Time time)
                return Equals(time);
            else
                return false;
        }

        public override int GetHashCode() => (Hours, Minutes, Seconds).GetHashCode();

        public int CompareTo(Time other){
            var HoursComp = Hours.CompareTo(other.Hours);
            if (HoursComp != 0) 
                return HoursComp;

            var MinutesComp = Minutes.CompareTo(other.Minutes);
            if (MinutesComp != 0) 
                return MinutesComp;

            return Seconds.CompareTo(other.Seconds);
        }

        public static bool operator ==(Time t1, Time t2) => Equals(t1, t2);
        public static bool operator !=(Time t1, Time t2) => !(t1 == t2);
        public static bool operator <(Time t1, Time t2) => t1.CompareTo(t2) < 0;
        public static bool operator >(Time t1, Time t2) => t1.CompareTo(t2) > 0;
        public static bool operator <=(Time t1, Time t2) => t1.CompareTo(t2) <= 0;
        public static bool operator >=(Time t1, Time t2) => t1.CompareTo(t2) >= 0;
        public static Time operator +(Time t1, Time t2) {

            long time1 = t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds;
            long time2 = t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds;

            long res = time1 + time2;

            var hours = (res / 3600)%24;
            var minutes = (res % 3600)/60;
            var seconds = res % 60;

            return new Time((byte)hours, (byte)minutes, (byte)seconds);
        }
        public static Time operator -(Time t1, Time t2) {

            long time1 = t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds;
            long time2 = t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds;

            long res = time1 - time2;
            if (res < 0)
                res = (24 * 3600) + res;

            Console.WriteLine(res);
            var hours = (res / 3600) % 24;
            var minutes = (res % 3600) / 60;
            var seconds = res % 60;

            return new Time((byte)hours, (byte)minutes, (byte)seconds);
        }
    }
}
