using System.Linq;

namespace ChainOfResponssibility.Poker.Validators.HandValidators
{
    public class TwoPairsValidation : HandValidation
    {
        protected override string IsValid(Card[] hand)
        {
            var gr = hand.GroupBy(x => x.Value);
            var pairs = gr.Where(x => x.Count() == 2);
            if (pairs != null && pairs.Count() == 2)
                return "You have pairs of " + string.Join(" and ", pairs.Select(x=>x.First().Value + "s"))+ " (Two Pairs)";

            return string.Empty;
        }
    }
}
