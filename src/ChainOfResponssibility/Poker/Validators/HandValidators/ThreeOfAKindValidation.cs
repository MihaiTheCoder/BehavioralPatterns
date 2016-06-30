using System.Linq;

namespace ChainOfResponssibility.Poker.Validators.HandValidators
{
    public class ThreeOfAKindValidation : HandValidation
    {
        protected override string IsValid(Card[] hand)
        {
            var gr = hand.GroupBy(x => x.Value);
            var OhBabyATripple = gr.FirstOrDefault(x => x.Count() == 3);
            if (OhBabyATripple != null)
                return "You have three of " + OhBabyATripple.First().Value + "s (Three of a kind)";

            return string.Empty;
        }
    }
}
