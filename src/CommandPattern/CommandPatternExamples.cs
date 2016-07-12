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
            Console.WriteLine(GetActors());
            GoToNextStep();

            StockExampleRunner stockExampleRunner = new StockExampleRunner();
            Console.WriteLine(stockExampleRunner.GetDescriptionOfExample());

            GoToNextStep();
            stockExampleRunner.RunWithRealStockSchedule();
            stockExampleRunner.RunWithMarketClosed();
            stockExampleRunner.RunWithMarketOpened();
            stockExampleRunner.RunWithMarketOpeningInTwoSeconds();

            GoToNextStep();
            Console.WriteLine(GetPitfalls());
            Console.WriteLine(CommandWithUndoDescription());

            GoToNextStep();

        }

        private static void GoToNextStep()
        {            
            Console.ReadKey();
            Console.Clear();
        }

        public static string GetPatternDescription()
        {
            return @"Patttern description:
Command pattern is a behavioral design pattern in which an object is used to encapsulate 
all information needed to perform an action or trigger an event at a later time
Uses:
1. Macro recording: all user actions are represented by command objects, a program can record a 
sequence of actions simply by keeping a list of the command objects as they are executed.
2. Undo
3. GUI buttons and menu items
4. Parallel processing
5. Transactional behavior ";
        }

        public static string GetActors()
        {
            return @"Actors:
Client: class that is making use of the command pattern, the one that uses the invoker, makes instance of commands, and passes the commands to the invoker
Invoker: Invokes the command (calls execute on the command)
Receiver: the class that the command is using as an implementation
Command interface: the interface for the commmands
Concrete Command: Concrete implementations of the command interface";
        }

        public static string GetPitfalls()
        {
            return @"Pitfalls:
Dependence on other patterns
Multiple commands having the same implementation";
        }

        public static string CommandWithUndoDescription()
        {
            return @"Undo functionality:
While it is true that it would be easy using Command pattern to implement at the invoker 
level undo/redo functionality, in practice this only works for simple examples, 
where all entities are at the same level. More details about undo can be seen at: 
http://gernotklingler.com/blog/implementing-undoredo-with-the-command-pattern/";
        }
    }
}
