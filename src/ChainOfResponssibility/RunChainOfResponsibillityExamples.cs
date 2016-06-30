using ChainOfResponssibility.Poker;
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

            while (true)
            {
                Console.Clear();
                Console.WriteLine(ExeucteFirstWhenConditionMatchesFlavorDescription());
                Console.WriteLine(ExecuteAllUntilConditionIsFalseFlavorDescription());
                Console.WriteLine(ExecuteAllFlavorDescritpion());
                Console.WriteLine("1: Money Spender (flavor 1)");
                Console.WriteLine("2: File Transfer (flavor 1)");
                Console.WriteLine("3: User Processor (flavor 1 and 3)");
                Console.WriteLine("4: pitfals");
                Console.WriteLine("5: Poker Game (flavor 1)");
                Console.Write("0: exit\r\n>");

                var keyChar = GoToNextStep();

                switch (keyChar)
                {
                    case '1':
                        CheckAuthority moneySpender = new CheckAuthority();

                        Console.WriteLine(moneySpender.GetDescriptionOfExample());
                        GoToNextStep();

                        moneySpender.PrintHowMuchEachCanSpend();
                        moneySpender.SpendMoney();
                        break;
                    case '2':
                        TransferFilesManager transferFilesManager = new TransferFilesManager();

                        Console.WriteLine(transferFilesManager.GetDescriptionOfExample());
                        GoToNextStep();
                        transferFilesManager.TransferFiles();
                        break;
                    case '3':
                        UserProcessor userProcessor = new UserProcessor();
                        userProcessor.DoStuff();
                        break;
                    case '4':
                        Console.WriteLine(GetPitfalls());
                        GoToNextStep();
                        break;
                    case '5':
                        PokerGame poke = new PokerGame();
                        poke.newGame();
                        break;
                }

                if (keyChar == '0')
                    break;
            }
        }

        private static char GoToNextStep()
        {
            var ch = Console.ReadKey().KeyChar;
            Console.Clear();
            return ch;
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
            return @"Flavor 2: Execute all elements of chain until the condition does not match";
        }

        public static string ExecuteAllFlavorDescritpion()
        {
            return @"Flavor 3: Execute all elements of chain";
        }
    }
}
