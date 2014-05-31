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
        //Uncomment the region beginning on line 55 to get pairs with no repitition of numbers and comment the region beginning on line 74
        //Uncomment the region beignning on line 74 to get pairs where repitition of numbers are allowed and comment the region beginning on line 55
        static void Main(string[] args)
        {
            List<CorrectNumber> allPairs = new List<CorrectNumber>();
            var dutyCycleDeviation = 0.015;
            double requestedDutyCycle = 0.10;
            var primes = new List<int>
            {
                2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97,101,103,107,109,113,127,131,137,139,149,151,157
            };
            var bestPair = new CorrectNumber();
            foreach (var prime in primes)
            {
                foreach (var i in primes)
                {
                    if (i != prime)
                    {
                        double value = (1.0 / (double)prime) + (1.0 / (double)i);
                        double dutyCycleDiffAbs = Math.Abs(requestedDutyCycle - value);
                        if ((dutyCycleDiffAbs < bestPair.DutyCycleDiffAbs) || (dutyCycleDiffAbs <= dutyCycleDeviation))
                        {
                            if (dutyCycleDiffAbs < bestPair.DutyCycleDiffAbs)
                            {
                                bestPair.Prime1 = prime;
                                bestPair.Prime2 = i;
                                bestPair.DutyCycle = value;
                                bestPair.DutyCycleDiffAbs = dutyCycleDiffAbs;
                            }
                            if (dutyCycleDiffAbs <= dutyCycleDeviation)
                            {
                                //Add the number to correct numbers

                                allPairs.Add(new CorrectNumber
                                {
                                    DutyCycle = value,
                                    DutyCycleDiffAbs = dutyCycleDiffAbs,
                                    Prime1 = prime,
                                    Prime2 = i
                                });
                            }


                            //Uncomment the code inside the region to include pairs where no number is repeated.
                            #region Pairs where no number is repeated repeated
                            //Find all pairs containing one of the numbers. It can not be anymore than 2.
                            List<CorrectNumber> listOfExistingPrimeTest =
                                allPairs.Where(
                                    x => (x.Prime1 == i) || (x.Prime1 == prime) || (x.Prime2 == i) || (x.Prime2 == prime)).ToList();
                            if (listOfExistingPrimeTest.Count > 1)
                            {
                                if ((prime == 23 && i == 17) || (prime == 23 && i == 19))
                                    Console.WriteLine("debug");
                                var orderedList = listOfExistingPrimeTest.OrderByDescending(x => x.DutyCycleDiffAbs).ToList();

                                //Remove all elements except the best one
                                orderedList.Remove(orderedList.ElementAt(orderedList.Count - 1));
                                allPairs = allPairs.Except(orderedList).ToList();
                            }
                            #endregion

                            //Uncomment the code inside the region to include pairs where not two pairs consists of the same numbers
                            #region Pairs where no pairs consists of the same numbers
                            //List<CorrectNumber> listOfExistingPrimes =
                            //    allPairs.Where(
                            //        x => ((x.Prime1 == i) && (x.Prime2 == prime)) || ((x.Prime1 == prime) && (x.Prime2 == i))).ToList();
                            //if (listOfExistingPrimes.Count > 1)
                            //{
                            //    //Find the worst pair and remove it from list of correct numbers
                            //    allPairs.Remove(
                            //        listOfExistingPrimes.OrderBy(x => x.DutyCycleDiffAbs)
                            //            .ToList()
                            //            .FirstOrDefault());
                            //}
                            #endregion
                        }
                    }

                }
            }

            Console.WriteLine("#### BEST MATCH ####");
            bestPair.Print();
            Console.WriteLine("#### ALL PAIRS ####");
            foreach (var correctNumber in allPairs)
            {
                Console.WriteLine(correctNumber.Prime1 + "--" + correctNumber.Prime2);
            }
            Console.WriteLine("#### NUMBER OF PAIRS ####");
            Console.WriteLine(allPairs.Count);
            Console.ReadKey();
        }
    }
}
