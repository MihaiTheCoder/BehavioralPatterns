using System.Linq;

namespace ChainOfResponssibility.Poker.Validators.HandValidators
{
    public class FullHouseValidation : HandValidation
    {
        protected override string IsValid(Card[] hand)
        {
            var gr = hand.GroupBy(x => x.Value);
            var pair = gr.FirstOrDefault(x => x.Count() == 2);
            if (pair != null)
            {
                var OhBabyATripple = gr.FirstOrDefault(x => x.Count() == 3);
                if (OhBabyATripple != null)
                    return "You have a Full House of " + OhBabyATripple.First().Value + "s (3) and " + pair.First().Value + "s (2)";
            }

            return string.Empty;
        }
    }
}
