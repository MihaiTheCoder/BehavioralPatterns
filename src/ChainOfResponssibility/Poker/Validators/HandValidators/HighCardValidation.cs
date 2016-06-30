using System.Linq;

namespace ChainOfResponssibility.Poker.Validators.HandValidators
{
    public class HighCardValidation : HandValidation
    {
        protected override string IsValid(Card[] hand)
        {
            return string.Format("You only have high cards, here I ordered them for you: {0}",
                string.Join(", ", hand.OrderByDescending(x => x.GetIntValue()).Select(x => x.ToString())));
        }
    }
}
