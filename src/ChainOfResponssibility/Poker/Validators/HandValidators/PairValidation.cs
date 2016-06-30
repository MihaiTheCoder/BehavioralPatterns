using System.Linq;

namespace ChainOfResponssibility.Poker.Validators.HandValidators
{
    public class PairValidation : HandValidation
    {
        protected override string IsValid(Card[] hand)
        {
            var gr = hand.GroupBy(x => x.Value);
            var pair = gr.FirstOrDefault(x => x.Count() == 2);
            if (pair != null)
                return "You have a pair of " + pair.First().Value + "s";

            return string.Empty;
        }
    }
}
