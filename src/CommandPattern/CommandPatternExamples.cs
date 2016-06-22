using CommandPattern.StocksExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class CommandPatternExamples
    {
        public static void Run()
        {
            Console.WriteLine(GetPatternDescription());
            GoToNextStep();

            StockExampleRunner stockExampleRunner = new StockExampleRunner();
            Console.WriteLine(stockExampleRunner.GetDescriptionOfExample());
            GoToNextStep();
            stockExampleRunner.Run();
            stockExampleRunner.Run();
            stockExampleRunner.Run();
            stockExampleRunner.Run();
        }

        private static void GoToNextStep()
        {            
            Console.ReadKey();
            Console.Clear();
        }

        public static string GetPatternDescription()
        {
            return @"
command pattern is a behavioral design pattern in which an object is used to encapsulate 
all information needed to perform an action or trigger an event at a later time
Uses:
1. Macro recording: f all user actions are represented by command objects, a program can record a 
sequence of actions simply by keeping a list of the command objects as they are executed.
2. Undo
3. GUI buttons and menu items
4. Parallel processing
5. Transactional behavior ";
        }
    }
}
