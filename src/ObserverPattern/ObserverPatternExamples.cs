using ObserverPattern.StockUpdateEvents;
using ObserverPattern.Twits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObserverPattern
{
    
    public class ObserverPatternExamples
    {
        public static void Run()
        {
            Console.WriteLine(GetDescription());
            Console.WriteLine(GetActors());
            Console.WriteLine(IsThisPubSub());

            StockUpdateEventsExample stockExample = new StockUpdateEventsExample();
            stockExample.RunSimple();

            GoToNextStep();            

            Console.WriteLine(GetLapsedLinstenerProblem());

            GoToNextStep();

            Console.WriteLine("Same business logic using events combined with RX library");
            stockExample.RunReactiveWithEvents();

            GoToNextStep();

            Console.WriteLine("Same business logic using RX library");
            stockExample.RunReactive();

            GoToNextStep();

            ObservableTwitsExample obsTwits = new ObservableTwitsExample();
            obsTwits.Run();

            GoToNextStep();
        }

        private static string GetDescription()
        {
            return @"
The observer pattern is a software design pattern in which an object, called the subject,
maintains a list of its dependents, called observers, and notifies them automatically of any state changes, 
usually by calling one of their methods. ";
        }

        private static string IsThisPubSub()
        {
            return @"
Observer/Observable pattern is mostly implemented in a synchronous way, 
i.e. the observable calls the appropriate method of all its observers when some event occurs. 
The Publisher/Subscriber pattern is mostly implemented in an asynchronous way (using message queue).
In the Observer/Observable pattern, the observers are aware of the observable. 
Whereas, in Publisher/Subscriber, publishers and subscribers don't need to know each other. 
They simply communicate with the help of message queues.
";
        }

        private static string GetActors()
        {
            return @"
Subject -> Notifies interested observers when an event occurs
Observer -> Registers to a subject, to be notified when a specific event happens
";
        }


        private static string GetLapsedLinstenerProblem()
        {
            return @"
The leak happens when a listener fails to unsubscribe from the publisher when it no longer needs to listen. 
Consequently, the publisher still holds a reference to the observer which prevents it from being garbage collected 
— including all other objects it is referring to — for as long as the publisher is alive, which could be until the end of the application.
This causes not only a memory leak, but also a performance degradation with an 'uninterested' observer receiving and acting on unwanted events";
        }
        private static void GoToNextStep()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
