using StrategyPattern.ShippingCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyPattern
{
    /// <summary>
    /// Client
    /// </summary>
    public class StrategyPatternExamples
    {
        public static void Run()
        {
            Console.WriteLine(GetDescription());
            Console.WriteLine(WhenToUse());
            GoToNextStep();
            ShippingMotivatingExample.Run();

            ShippingWithStrategyExample.Run();

            //TODO:add more examples
            //Show the switch moving problem
        }

        private static string GetDescription()
        {
            return @"Strategy pattern (also known as the policy pattern) is a software design pattern 
that enables an algorithm's behavior to be selected at runtime. The strategy pattern
defines a family of algorithms,
encapsulates each algorithm, and
makes the algorithms interchangeable within that family.";
        }

        public static string WhenToUse()
        {
            return @"Whenever you start to use a switch statement you should ask yourself whether you can use Strategy Pattern instead. ";
        }


        private static void GoToNextStep()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
