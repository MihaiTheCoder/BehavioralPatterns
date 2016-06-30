using System.Linq;

namespace ChainOfResponssibility.Poker.Validators.HandValidators
{
    public class FlushValidation : HandValidation
    {
        protected override string IsValid(Card[] hand)
        {
            var gr = hand.GroupBy(x => x.Suite);
            var flush = gr.FirstOrDefault(x => x.Count() == 5);
            if (flush != null)
                return "You have a Flush of " + flush.First().Suite + "s";

            return string.Empty;
        }
    }
}
