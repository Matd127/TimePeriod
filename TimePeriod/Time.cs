using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePeriod
{   /// <summary>
    /// Struktura czasu - Time 
    /// </summary>
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        /// <summary>
        /// Metoda pozwalajaca na sprawdzenie, czy liczba godzin jest prawidłowa
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public static void CheckTime(byte? hours = null, byte? minutes = null, byte? seconds = null){
            if (hours != null)
                if (hours > 23 || hours < 0)
                    throw new ArgumentOutOfRangeException("Niepoprawna liczba godzin");

            if (minutes != null)
                if (minutes > 59 || minutes < 0)
                    throw new ArgumentOutOfRangeException("Niepoprawna liczba minut");

            if (seconds != null)
                if (seconds > 59 || seconds < 0)
                    throw new ArgumentOutOfRangeException("Niepoprawna liczba sekund");

        }
        private readonly byte _hours;
        private readonly byte _minutes;
        private readonly byte _seconds;

        /// <summary>
        /// Wartośc godzin
        /// </summary>
        public byte Hours => _hours;
        /// <summary>
        /// Wartośc minut
        /// </summary>
        public byte Minutes => _minutes;
        /// <summary>
        /// Wartość sekund
        /// </summary>
        public byte Seconds => _seconds;

        /// <summary>
        /// Konstruktor z 3 parametrami - godzinami, minutami oraz sekundami
        /// </summary>
        /// <param name="hours">Przypisuje wartośc godzin</param>
        /// <param name="minutes">Przypisuje wartośc minut</param>
        /// <param name="seconds">Przypisuje wartośc sekund</param>
        public Time(byte hours, byte minutes, byte seconds) {

            CheckTime(hours, minutes, seconds);

            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
        }

        /// <summary>
        /// Konstruktor z 2 parametrami - godzinami oraz minutami, pozostałe wartości mają wartość domyślną
        /// </summary>
        /// <param name="hours">Przypisuje wartośc godzin</param>
        /// <param name="minutes">Przypisuje wartośc minut</param>
        public Time(byte hours, byte minutes){

            CheckTime(hours, minutes);
            _hours = hours;
            _minutes = minutes;
            _seconds = 0;
        }
        /// <summary>
        /// Konstruktor z 1 parametrem - godzinami, pozostałe wartości mają wartość domyślną
        /// </summary>
        /// <param name="hours">Przypisuje wartość godzin</param>
        public Time(byte hours){
            CheckTime(hours);
            _hours = hours;
            _minutes = 0;
            _seconds = 0;
        }

        /// <summary>
        /// Konstruktor w postaci string
        /// </summary>
        /// <param name="time">Czas w postaci string, który zostanie zamieniony na byte i przypisany do zmiennych</param>
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
        /// <summary>
        /// Metoda zwracająca czas w formie string
        /// </summary>
        /// <returns>Zwraca w formacie string godziny:minuty:sekundy</returns>
        public override string ToString() => $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";

        /// <summary>
        /// Implementacja interfejsu IEquatable<Time>
        /// </summary>
        /// <param name="other">Inny czas, który chcemy porównać</param>
        /// <returns>Zwracamy true, gdy oba obiekty czasu są sobie równe</returns>
        public bool Equals(Time other) => Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;

        public override bool Equals(object obj){
            if (obj is Time time)
                return Equals(time);
            else
                return false;
        }
        /// <summary>
        /// Implementacja interfejsu IEquatable<Time>
        /// </summary>
        /// <returns>Zwraca unikalny numer obiektu</returns>
        public override int GetHashCode() => (Hours, Minutes, Seconds).GetHashCode();
        /// <summary>
        /// Implementacja interfejsu IComparable<Time>
        /// </summary>
        /// <param name="other">Parametr typu time, do którego będziemy prorównywać</param>
        public int CompareTo(Time other){
            var HoursComp = Hours.CompareTo(other.Hours);
            if (HoursComp != 0) 
                return HoursComp;

            var MinutesComp = Minutes.CompareTo(other.Minutes);
            if (MinutesComp != 0) 
                return MinutesComp;

            return Seconds.CompareTo(other.Seconds);
        }

        /// <summary>
        /// Przeciążenie operatora ==
        /// </summary>
        /// <param name="t1">Pierwszy parametr typu Time</param>
        /// <param name="t2">Drugi parametr typu Time</param>
        /// <returns>Zwraca true, jeśli oba parametry są sobie równe, w przeciwnym przypadku zwraca false</returns>
        public static bool operator ==(Time t1, Time t2) => Equals(t1, t2);
        /// <summary>
        /// Przeciążenie operatora !=
        /// </summary>
        /// <param name="t1">Pierwszy parametr typu Time</param>
        /// <param name="t2">Drugi parametr typu Time</param>
        /// <returns>Zwraca true, jęeśli oba parametry nie są sobie równe, w przeciwnym przypadku zwraca false</returns>
        public static bool operator !=(Time t1, Time t2) => !(t1 == t2);
        /// <summary>
        /// Przeciążenie operatora <
        /// </summary>
        /// <param name="t1">Pierwszy parametr typu Time</param>
        /// <param name="t2">Drugi parametr typu Time</param>
        /// <returns>Zwraca true jeśli pierwszy parametr typu time jest mniejszy niż drugi w przeciwnym przypadku zwraca false</returns>
        public static bool operator <(Time t1, Time t2) => t1.CompareTo(t2) < 0;
        /// <summary>
        /// Przeciążenie operatora >
        /// </summary>
        /// <param name="t1">Pierwszy parametr typu Time</param>
        /// <param name="t2">Drugi parametr typu Time</param>
        /// <returns>Zwraca true jeśli pierwszy parametr typu time jest większy niż drugi w przeciwnym przypadku zwraca false</returns>
        public static bool operator >(Time t1, Time t2) => t1.CompareTo(t2) > 0;
        /// <summary>
        /// Przeciążenie operatora <=
        /// </summary>
        /// <param name="t1">Pierwszy parametr typu Time</param>
        /// <param name="t2">Drugi parametr typu Time</param>
        /// <returns>Zwraca true jeśli pierwszy parametr typu time jest mniejszy lub równy drugiemu w przeciwnym przypadku zwraca false</returns>
        public static bool operator <=(Time t1, Time t2) => t1.CompareTo(t2) <= 0;
        /// <summary>
        /// Przeciążenie operatora >=
        /// </summary>
        /// <param name="t1">Pierwszy parametr typu Time</param>
        /// <param name="t2">Drugi parametr typu Time</param>
        /// <returns>Zwraca true jeśli pierwszy parametr typu time jest większy lub równy drugiemu w przeciwnym przypadku zwraca false</returns>
        public static bool operator >=(Time t1, Time t2) => t1.CompareTo(t2) >= 0;
        /// <summary>
        /// Przeciążenie operatora +
        /// </summary>
        /// <param name="t1">Pierwszy parametr typu Time</param>
        /// <param name="t2">Drugi parametr typu Time</param>
        /// <returns>Zwraca nowy obiekt typu Time, który wskazujacy na godzinę po dodaniu dwóch dowolnych godzin</returns>
        public static Time operator +(Time t1, Time t2) {

            long time1 = t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds;
            long time2 = t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds;

            long res = time1 + time2;

            var hours = (res / 3600)%24;
            var minutes = (res % 3600)/60;
            var seconds = res % 60;

            return new Time((byte)hours, (byte)minutes, (byte)seconds);
        }
        /// <summary>
        /// Przeciążenie operatora - 
        /// </summary>
        /// <param name="t1">Pierwszy parametr typu Time</param>
        /// <param name="t2">Drugi parametr typu Time</param>
        /// <returns>Zwraca nowy obiekt typu Time, który wskazujacy na godzinę po odjęciu dwóch dowolnych godzin</returns>
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
