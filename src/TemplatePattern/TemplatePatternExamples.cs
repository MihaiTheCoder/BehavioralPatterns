using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePattern
{
    public class TemplatePatternExamples
    {
        public static void Run()
        {
            Console.WriteLine(GetDescription());
            GoToNextStep();
            WorkersExample.WorkersExample.Run();
            GoToNextStep();
            GameExample.GameExample.Run();
        }        

        private static string GetDescription()
        {
            return @"
In software engineering, the template method pattern is a behavioral design pattern that defines the program skeleton of an algorithm in an operation,
defering some steps to subclasses. It lets one redefine certain steps of an algorithm without changing the algorithm's structure.
Template pattern works using 'the Hollywood principle' from the base class point of view: 'Don't call us, we'll call you'";
        }

        private static void GoToNextStep()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
