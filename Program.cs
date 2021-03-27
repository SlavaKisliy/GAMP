using System;
using System.Timers;

namespace GAMP
{
    class Program
    {
        private static Timer SetTimer()
        {
            var timer = new System.Timers.Timer(1000);
            
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            return timer;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            new GAMPSender().Send().GetAwaiter().GetResult();

            Console.WriteLine("Sent !");
        }

        static void Main(string[] args)
        {
            using var timer = SetTimer();

            Console.WriteLine("Press any key to stop");
            Console.ReadKey();
        }
    }
}
