using System;

namespace TimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            Time time = new Time(23, 59, 59);
            Console.WriteLine(time.ToString());
            Time time1 = new Time("22");
            Console.WriteLine(time1.ToString());
        }
    }
}
