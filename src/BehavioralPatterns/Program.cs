using ChainOfResponssibility;
using ChainOfResponssibility.PurchaseExample;
using CommandPattern;
using IteratorPattern;
using MediatorPattern;
using MememntoPattern;
using ObserverPattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BehavioralPatterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("1: Chain of responsibility\r\n");
                Console.Write("2: Iterator Pattern\r\n");
                Console.Write("3: Observer Pattern\r\n");
                Console.Write("4: Command Pattern\r\n");
                Console.Write("5: Mediator Pattern\r\n");
                Console.Write("6: Memento Pattern\r\n");
                Console.Write("0: exit\r\n>");
                var key = Console.ReadKey();

                Console.Clear();

                switch (key.KeyChar)
                {
                    case '1':
                        //Chain of responsibillity
                        //This is usefull when you have a request and you don't know who should process it
                        ChainOfResponsibillityExamples.Run();
                        break;
                    case '2':
                        IteratorPatternExamples.Run();
                        break;
                    case '3':
                        ObserverPatternExamples.Run();
                        break;
                    case '4':
                        CommandPatternExamples.Run();
                        break;
                    case '5':
                        MediatorPatternExamples.Run();
                        break;
                    case '6':
                        MementoPatternExamples.Run();
                        break;
                }
                if (key.KeyChar == '0')
                    break;
            }
        }
    }
}
