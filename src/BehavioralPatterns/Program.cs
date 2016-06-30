using ChainOfResponssibility;
using CommandPattern;
using IteratorPattern;
using MediatorPattern;
using MememntoPattern;
using ObserverPattern;
using StatePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BehavioralPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StatePatternExamples.Run();
            GoToNextStep();
            //Chain of responsibillity
            //This is usefull when you have a request and you don't know who should process it
            ChainOfResponsibillityExamples.Run();
            GoToNextStep();

            CommandPatternExamples.Run();
            GoToNextStep();

            IteratorPatternExamples.Run();
            GoToNextStep();

            IteratorPatternExamples.Run();

            GoToNextStep();

            MediatorPatternExamples.Run();

            GoToNextStep();

            MementoPatternExamples.Run();

            GoToNextStep();

            ObserverPatternExamples.Run();
            GoToNextStep();


        }

        private static void GoToNextStep()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
