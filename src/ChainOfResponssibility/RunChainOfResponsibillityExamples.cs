using ChainOfResponssibility.PurchaseExample;
using ChainOfResponssibility.TransferFileExample;
using ChainOfResponssibility.Validators.UserEntities;
using System;

namespace ChainOfResponssibility
{
    public class ChainOfResponsibillityExamples
    {
        public static void Run()
        {
            Console.WriteLine(GetPatternDescription());
            GoToNextStep();

            Console.WriteLine(ExeucteFirstWhenConditionMatchesFlavorDescription());
            GoToNextStep();

            CheckAuthority moneySpender = new CheckAuthority();

            Console.WriteLine(moneySpender.GetDescriptionOfExample());
            GoToNextStep();

            moneySpender.PrintHowMuchEachCanSpend();
            moneySpender.SpendMoney();
            GoToNextStep();

            TransferFilesManager transferFilesManager = new TransferFilesManager();

            Console.WriteLine(transferFilesManager.GetDescriptionOfExample());
            GoToNextStep();
            transferFilesManager.TransferFiles();

            GoToNextStep();
            Console.WriteLine(ExecuteAllUntilConditionIsFalseFlavorDescription());
            Console.WriteLine(ExecuteAllFlavorDescritpion());
            GoToNextStep();

            UserProcessor userProcessor = new UserProcessor();
            userProcessor.DoStuff();

            GoToNextStep();
            Console.WriteLine(GetPitfalls());
        }

        private static void GoToNextStep()
        {
            Console.ReadKey();
            Console.Clear();
        }

        public static string GetPatternDescription()
        {
            return @"Pattern description:
Decouples sender and receiver (as a sender you don't know who will handle the request/ as a receiver you don't know who the sender is necessary)
Hierarchical in nature
When using the Chain of Responsibility is more effective:
More than one object can handle a command
The handler is not known in advance
The handler should be determined automatically
It’s wished that the request is addressed to a group of objects without explicitly specifying its receiver
The group of objects that may handle the command must be specified in a dynamic way.
Examples in real life:
 -java.util.logging.Logger.#log()
 -javax.servlet.Filter#doFilter()
 -Spring Security Filter Chain";
        }

        public static string GetPitfalls()
        {
            return @"Pitfalls:
Handling/Handler guarantee - you won't be sure that someone can process the request
Runtime configuration risk - the order matters/and it might be that the chain is not configured correctly
Chain length/performance issues - in theory you could see a chain that is too big, and it would be a bottleneck in performance";
        }

        public static string ExeucteFirstWhenConditionMatchesFlavorDescription()
        {
            return @"Flavor 1: Execute first that matches the condition and exit";
        }

        public static string ExecuteAllUntilConditionIsFalseFlavorDescription()
        {
            return @"Flavor 2 of chain of responssibility:Execute all elements of chain until the condition does not match";
        }

        public static string ExecuteAllFlavorDescritpion()
        {
            return @"Flavor 3 of chain of responssibility: Execute all elements of chain";
        }
    }
}
