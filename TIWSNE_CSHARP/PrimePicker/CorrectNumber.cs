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
        public double Num1;
        public double Num2;

        public CorrectNumber()
        {
            DutyCycleDiffAbs = 25;
        }

        public void Print()
        {
            Console.WriteLine("Num1: " + Num1);
            Console.WriteLine("Num2: " + Num2);
            Console.WriteLine("DutyCycle: " + DutyCycle);
            Console.WriteLine("DutyCycleDiffAbs: " + DutyCycleDiffAbs);
        }
    }
}
