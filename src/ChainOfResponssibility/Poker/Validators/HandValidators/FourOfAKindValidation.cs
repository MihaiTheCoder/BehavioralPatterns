using System.Linq;

namespace ChainOfResponssibility.Poker.Validators.HandValidators
{
    public class FourOfAKindValidation : HandValidation
    {
        protected override string IsValid(Card[] hand)
        {
            var gr = hand.GroupBy(x => x.Value);
            var four = gr.FirstOrDefault(x => x.Count() == 4);
            if (four != null)
                return "You have Four of " + four.First().Value + "s (Four of a kind)";

            return string.Empty;
        }
    }
}
