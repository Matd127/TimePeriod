using System;

namespace TimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            Time time = new Time(23, 59, 59);
            Console.WriteLine(time.ToString());
            Time time1 = new Time(1, 0, 0);
            Time time2 = new Time(2, 0, 0);
            Console.WriteLine(time1.ToString());
            Console.WriteLine(time2.ToString());
            Console.WriteLine(time1-time2);
        }
    }
}
