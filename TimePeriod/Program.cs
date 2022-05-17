using System;

namespace TimeTimePeriod
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

            TimePeriod timePeriod = new TimePeriod("129:31:16");
            Console.WriteLine(timePeriod.ToString());
            timePeriod = new TimePeriod(55);
            Console.WriteLine(timePeriod.ToString());
            timePeriod = new TimePeriod(168, 55, 48);
            Console.WriteLine(timePeriod.ToString());
            timePeriod = new TimePeriod(180,0);
            Console.WriteLine(timePeriod.ToString());
            timePeriod = new TimePeriod(0,7);
            Console.WriteLine(timePeriod.ToString());
        }
    }
}
