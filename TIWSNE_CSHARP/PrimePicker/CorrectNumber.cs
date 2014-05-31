using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePicker
{
    class CorrectNumber
    {
        public double DutyCycleDiffAbs;
        public double DutyCycle;
        public int Prime1;
        public int Prime2;

        public CorrectNumber()
        {
            DutyCycleDiffAbs = 25;
        }

        public void Print()
        {
            Console.WriteLine("Prime 1: " + Prime1);
            Console.WriteLine("Prime 2: " + Prime2);
            Console.WriteLine("Duty cycle: " + DutyCycle);
            Console.WriteLine("Duty cycle difference: " + DutyCycleDiffAbs);
        }
    }
}
