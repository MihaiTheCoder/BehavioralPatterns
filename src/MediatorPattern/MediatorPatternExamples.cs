using MediatorPattern.AirTrafficControl;
using MediatorPattern.StockExchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern
{    
    public class MediatorPatternExamples
    {
        public static void Run()
        {
            Console.WriteLine(GetPatternDescription());
            Console.WriteLine(GetActors());

            //GoToNextStep();

            //StockExchangeExample stockExample = new StockExchangeExample();
            //stockExample.Run();

            GoToNextStep();
            AirTrafficControlExample airTraficExample = new AirTrafficControlExample();
            airTraficExample.Run();
        }

        static string GetPatternDescription()
        {
            return @"Pattern description:
With the mediator pattern, communication between objects is encapsulated with a mediator object. 
Objects no longer communicate directly with each other, but instead communicate through the mediator. 
This reduces the dependencies between communicating objects, thereby lowering the coupling.";
        }

        static string GetActors()
        {
            return @"Actors:
Mediator: interface of the mediator, that defines what messages does it mediate between colleagues.
Concrete Mediator: implementation of the interface
Colleague: objects that communicate through the mediator
";
        }

        private static void GoToNextStep()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
