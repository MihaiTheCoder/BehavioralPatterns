using MediatorPattern.FlightAirTrafficControl;
using MediatorPattern.GroundAirTrafficControl;
using MediatorPattern.StockExchange;
using System;

namespace MediatorPattern
{
    public class MediatorPatternExamples
    {
        public static void Run()
        {
            Console.WriteLine(GetPatternDescription());
            Console.WriteLine(GetActors());
            Console.WriteLine(WhenToUseIt());
            Console.WriteLine(GetDisadvances());
            GoToNextStep();

            StockExchangeExample stockExample = new StockExchangeExample();
            stockExample.Run();

            GoToNextStep();
            GroundAirTrafficControlExample groundAirControl = new GroundAirTrafficControlExample();
            groundAirControl.Run();

            GoToNextStep();

            FlightAirTrafficControlExample flightAirControl = new FlightAirTrafficControlExample();
            flightAirControl.Run();

            GoToNextStep();

            //Taxi/Taxi center example
            //Chat application
            //GUI libraries
            //https://www.javacodegeeks.com/2015/09/mediator-design-pattern.html
            //Dispatcher from facebook -> flux -> https://youtu.be/nYkdrAPrdcw?list=PLb0IAmt7-GS188xDYE-u1ShQmFFGbrk0v&t=735
            // It's almost pub/sub, pub sub is implemented using mediator design pattern, but a mediator assumes more knowledge of the colleagues

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

        static string WhenToUseIt()
        {
            return @"When to use it:
Identify a collection of interacting objects whose interaction needs simplification
Get a new abstract class that encapsulates that interaction
Create a instance of that class and redo the interaction with that class alone
But, don’t play God!
";
        }

        static string GetDisadvances()
        {
            return @"Disatvantages:
Mediator can become ver complicated as more colleagues are handled";
        }

        private static void GoToNextStep()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
