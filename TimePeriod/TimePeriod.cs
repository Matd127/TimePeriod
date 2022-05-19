using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTimePeriod
{
    /// <summary>
    /// 
    /// </summary>
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        /// <summary>
        /// Metoda sprawdzająca poprawność parametrów
        /// </summary>
        /// <param name="hours">godziny</param>
        /// <param name="minutes">minuty</param>
        /// <param name="seconds">sekundy</param>
        public static void CheckTime(int? hours = null, int? minutes = null, int? seconds = null)
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
        public long PeriodOfTime { get; }
        /// <summary>
        /// Konstruktor z 3 parametrami - godzinami, minutami, sekundami
        /// </summary>
        /// <param name="hours">godziny</param>
        /// <param name="minutes">minuty</param>
        /// <param name="seconds">sekundy</param>
        public TimePeriod(int hours, int minutes, int seconds) {
            CheckTime(hours, minutes, seconds);
            PeriodOfTime = (hours * 3600) + (minutes * 60) + seconds;
        }

        /// <summary>
        /// Konstruktor z 2 parametrami - godzinami i minutami 
        /// </summary>
        /// <param name="hours">godziny</param>
        /// <param name="minutes">minuty</param>
        public TimePeriod(int hours, int minutes) {
            CheckTime(hours, minutes);
            PeriodOfTime = (hours * 3600) + (minutes * 60);
        }
        /// <summary>
        /// Konstruktor z 1 parametrem - sekundami 
        /// </summary>
        /// <param name="seconds">sekundy</param>
        public TimePeriod(long seconds)
        {
            if (seconds < 0) throw new ArgumentException("Niepoprawna liczba sekund");
            PeriodOfTime = seconds;
        }
        /// <summary>
        /// Konstruktor z odcinkiem czasu w formie string
        /// </summary>
        /// <param name="timePeriod">Odcinek czasu</param>
        public TimePeriod(string timePeriod) {
            string[] t = timePeriod.Split(":");
            int[] tim = new int[3];

            for (int i = 0; i < t.Length; i++) {
                tim[i] = int.Parse(t[i]);
            }
            CheckTime(tim[0], tim[1], tim[2]);

            PeriodOfTime = (tim[0] * 3600) + (tim[1] * 60) + tim[2];
        }
        /// <summary>
        /// Konstruktor różnicy punktów czasowych
        /// </summary>
        /// <param name="t1">Pierwszy punkt czasowy</param>
        /// <param name="t2">Drugi punkt czasowy</param>
        public TimePeriod(Time t1, Time t2)
        {
            long timeOne = t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds;
            long timeTwo = t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds;

            var timeDifference = Math.Abs(timeOne - timeTwo);
            PeriodOfTime = timeDifference;
        }
        /// <summary>
        /// Metoda zwracająca odcinek czasu w formie stirng
        /// </summary>
        /// <returns>Zwraca w formacie string godziny:minuty:sekundy</returns>
        public override string ToString() {

            long hours = (PeriodOfTime / 3600);
            long minutes = (PeriodOfTime - (hours * 3600)) / 60;
            long seconds = (PeriodOfTime - ((hours * 3600) + (minutes * 60)));

            return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }
        /// <summary>
        /// Porównywanie dwóch odcinków i określa, który jest większy
        /// </summary>
        /// <param name="other">Odcinek czasu</param>
        public int CompareTo(TimePeriod other) => PeriodOfTime.CompareTo(other.PeriodOfTime);

        /// <summary>
        /// Porównywanie 2 odcinków czasu
        /// </summary>
        /// <param name="other">Odcinek czasu</param>
        public bool Equals(TimePeriod other) => PeriodOfTime == other.PeriodOfTime;
        public override bool Equals(object obj) {
            if (obj is TimePeriod tp)
                return Equals(tp);
            else
                return false;
        }
        /// <summary>
        /// Implementacja interfejsu IEquatable<TimePeriod>
        /// </summary>
        /// <returns>Zwraca unikalny numer obiektu</returns>
        public override int GetHashCode() => PeriodOfTime.GetHashCode();
        /// <summary>
        /// Przeciążenie operatora == 
        /// </summary>
        /// <param name="tp1">Pierwszy odcinek czasu</param>
        /// <param name="tp2">Drugi odcinek czasu</param>
        /// <returns>Zwraca true, jeśli oba parametry są sobie równe, w przeciwnym przypadku zwraca false</returns>
        public static bool operator ==(TimePeriod tp1, TimePeriod tp2) => tp1.Equals(tp2);
        /// <summary>
        /// Przeciążenie operatora != 
        /// </summary>
        /// <param name="tp1">Pierwszy odcinek czasu</param>
        /// <param name="tp2">Drugi odcinek czasu</param>
        /// <returns>Zwraca true, jeśli oba parametry nie są sobie równe, w przeciwnym przypadku zwraca false</returns>
        public static bool operator !=(TimePeriod tp1, TimePeriod tp2) => !(tp1 == tp2);
        /// <summary>
        /// Przeciążenie operatora <
        /// </summary>
        /// <param name="tp1">Pierwszy odcinek czasu</param>
        /// <param name="tp2">Drugi odcinek czasu</param>
        /// <returns>Zwraca true jeśli pierwszy parametr typu timeperiod jest mniejszy niż drugi w przeciwnym przypadku zwraca false</returns>
        public static bool operator <(TimePeriod tp1, TimePeriod tp2) => tp1.CompareTo(tp2) < 0;
        /// <summary>
        /// Przeciążenie operatora <=
        /// </summary>
        /// <param name="tp1">Pierwszy odcinek czasu</param>
        /// <param name="tp2">Drugi odcinek czasu</param>
        /// <returns>Zwraca true jeśli pierwszy parametr typu timeperiod jest mniejszy lub równy drugiemu w przeciwnym przypadku zwraca false</returns>
        public static bool operator <=(TimePeriod tp1, TimePeriod tp2) => tp1.CompareTo(tp2) <= 0;
        /// <summary>
        /// Przeciążenie operatora >
        /// </summary>
        /// <param name="tp1">Pierwszy odcinek czasu</param>
        /// <param name="tp2">Drugi odcinek czasu</param>
        /// <returns>Zwraca true jeśli pierwszy parametr typu timeperiod jest większy niż drugi w przeciwnym przypadku zwraca false</returns>
        public static bool operator >(TimePeriod tp1, TimePeriod tp2) => tp1.CompareTo(tp2) > 0;
        /// <summary>
        /// Przeciążenie operatora >=
        /// </summary>
        /// <param name="tp1">Pierwszy odcinek czasu</param>
        /// <param name="tp2">Drugi odcinek czasu</param>
        /// <returns>>Zwraca true jeśli pierwszy parametr typu timeperiod jest większy lub równy drugiemu w przeciwnym przypadku zwraca false</returns>
        public static bool operator >=(TimePeriod tp1, TimePeriod tp2) => tp1.CompareTo(tp2) >= 0;

        /// <summary>
        /// Suma dwóch odcinków czasu
        /// </summary>
        /// <param name="tp1">Pierwszy odcinek czasu</param>
        /// <param name="tp2">Drugi odcinek czasu</param>
        /// <returns>Zwraca nowy obiekt typu timeperiod, który jest sumą dwóch odcinków</returns>
        public static TimePeriod operator +(TimePeriod tp1, TimePeriod tp2) => new(tp1.PeriodOfTime + tp2.PeriodOfTime);

        /// <summary>
        /// Różnica odcinków czasu
        /// </summary>
        /// <param name="tp1">Pierwszy odcinek czasu</param>
        /// <param name="tp2">Drugi odcinek czasu</param>
        /// <returns>Zwraca nowy obiekt typu timeperiod, który jest różnicą dwóch odcinków</returns>
        public static TimePeriod operator -(TimePeriod tp1, TimePeriod tp2){
            if (tp1 < tp2)
                throw new ArgumentOutOfRangeException();
            else
                return new TimePeriod(tp1.PeriodOfTime - tp2.PeriodOfTime);
        }
    }

}
