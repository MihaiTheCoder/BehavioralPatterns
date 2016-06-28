using ChainOfResponssibility;
using CommandPattern;
using IteratorPattern;
using MediatorPattern;
using MememntoPattern;
using ObserverPattern;
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
            //Chain of responsibillity
            //This is usefull when you have a request and you don't know who should process it
            ChainOfResponsibillityExamples.Run();
            Console.ReadKey();
            Console.Clear();

            CommandPatternExamples.Run();
            Console.ReadKey();
            Console.Clear();

            IteratorPatternExamples.Run();
            Console.ReadKey();

            IteratorPatternExamples.Run();

            Console.ReadKey();

            MediatorPatternExamples.Run();

            Console.ReadKey();

            MementoPatternExamples.Run();


            ObserverPatternExamples.Run();
            Console.ReadKey();
        }
    }
}
