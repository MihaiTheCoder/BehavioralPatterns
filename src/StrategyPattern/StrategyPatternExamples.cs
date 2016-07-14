using StrategyPattern.ArrangeInterview;
using StrategyPattern.ArrangeInterview.Strategy;
using StrategyPattern.LoopWithException;
using StrategyPattern.LoopWithoutLoop;
using StrategyPattern.ShippingCalculator;
using System;

namespace StrategyPattern
{
    /// <summary>
    /// Client
    /// </summary>
    public class StrategyPatternExamples
    {
        public static void Run()
        {
            LoopWithExceptionExample.Run();

            ArrangeInterviewMotivationalExample.Run(InterviewPersons.Get());
            
            Console.WriteLine(GetDescription());
            Console.WriteLine(WhenToUse());
            GoToNextStep();
            ShippingMotivatingExample.Run();

            Console.WriteLine("Now the same example, but implemented with strategy pattern");
            ShippingWithStrategyExample.Run();

            ArrangeInterviewMotivationalExample.Run(InterviewPersons.Get());

            //Show the switch moving problem
            ArrangeInterviewExample.Run(InterviewPersons.Get());

            //This is just for fun (Challenged to loop without using conditions/loops)
            LoopWithExceptionExample.Run();
            //This is just for fun (Challenged to loop without using conditions/loops)
            MagnificLoopExample.Run();
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
