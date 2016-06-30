using ChainOfResponssibility.Poker.Validators.HandValidators;
using System;
using System.Linq;

namespace ChainOfResponssibility.Poker
{
    public class PokerGame
    {
        public void newGame()
        {
            Console.WriteLine("!!NOT AN ACTUAL POKER GAME!!{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", Environment.NewLine,
                "This tells you what hand you have",
                "Just enter the 5 cards you have, separated with spaces, and press enter",
                "Card values: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A",
                "Card Suites: H, D, C, S",
                "ex.:\"QH AH JH KH 10H\" (yes that is a royal flush right there)");

            string cards = string.Empty;
            while (cards.ToLower()!="exit")
            {
                Console.Write(">");
                cards = Console.ReadLine();

                try
                {
                    var hand = cards.Split(' ').Select(x => Card.Parse(x)).OrderBy(x=>x.GetIntValue()).ToArray();
                    Console.WriteLine(HandValidationFactory.GetValidation().Validate(hand));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
            }
            Console.Clear();
        }
    }
}
