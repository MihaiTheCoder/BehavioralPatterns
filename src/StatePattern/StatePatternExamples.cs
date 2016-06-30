using StatePattern.FanExample;
using StatePattern.ScrumExample;
using StatePattern.TVExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatePattern
{
    public class StatePatternExamples
    {
        public static void Run()
        {
            TVMotivationalExample.Run();

            GoToNextStep();

            TVExampleRunner.Run();

            GoToNextStep();

            FanMotivationalExample.Run();

            GoToNextStep();

            FanWithStatePatternExample.Run();

            GoToNextStep();

            ScrumMotivationalExample.Run();

            GoToNextStep();
            ScrumStatePatternExample.Run();
        }

        private static void GoToNextStep()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
