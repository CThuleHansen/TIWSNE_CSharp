using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePicker
{
    class Program
    {
        //Additional prime numbers can be found here: http://coding.pressbin.com/70/List-of-primes-as-CSV-for-PHP-etc
        static void Main(string[] args)
        {
            double requestedDutyCycle = 0.20;
            var primes = new List<double>
            {
                2,
                3,
                5,
                7,
                11,
                13,
                17,
                19,
                23,
                29,
                31,
                37,
                41,
                43,
                47,
                53,
                59,
                61,
                67,
                71,
                73,
                79,
                83,
                89,
                91
            };
            var chosenNumber = new CorrectNumber();
            foreach (var prime in primes)
            {
                foreach (var i in primes)
                {
                    if (i != prime)
                    {
                        double value = (1 / prime) + (1 / i);
                        double dutyCycleDiffAbs = Math.Abs(requestedDutyCycle - value);
                        if (dutyCycleDiffAbs < chosenNumber.DutyCycleDiffAbs)
                        {
                            chosenNumber.Num1 = prime;
                            chosenNumber.Num2 = i;
                            chosenNumber.DutyCycle = value;
                            chosenNumber.DutyCycleDiffAbs = dutyCycleDiffAbs;
                        }
                    }

                }
            }
            chosenNumber.Print();
            Console.ReadKey();
        }
    }
}
