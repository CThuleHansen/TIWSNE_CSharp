using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace AlgorithmImplementation
{
    class Program
    {
        private static bool radioOn = false;
        private static int counter;
        private static int prime1 = 5;
        private static int prime2 = 19;
        private static int radioOns = 0;
        static void Main(string[] args)
        {
            counter = 0;
            //1 millisecond interval
            var timer = new Timer(1);
            //Autoreset the timer
            timer.AutoReset = true;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            Thread.Sleep(1000);
            timer.Stop();
            Console.WriteLine("RadioOns: " + radioOns);
            Console.WriteLine("Counter: " + counter);
            Console.WriteLine("Duty-cycle: " + (double)radioOns / counter);
            Console.ReadKey();
        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            counter++;
            if (counter % prime1 == 0 || counter % prime2 == 0)
            {
                if (radioOn == false)
                {
                    radioOn = true;
                    radioOns++;
                    //Console.WriteLine("Radio on");
                }
            }
            if (radioOn)
            {
                radioOn = false;
                //Console.WriteLine("Radio off");
            }

        }
    }

}
