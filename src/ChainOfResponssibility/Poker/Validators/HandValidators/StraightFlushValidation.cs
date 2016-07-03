using System.Linq;

namespace ChainOfResponssibility.Poker.Validators.HandValidators
{
    public class StraightFlushValidation : HandValidation
    {
        private StraightValidation straight;
        private FlushValidation flush;

        public StraightFlushValidation()
        {
            straight = new StraightValidation();
            flush = new FlushValidation();
        }

        protected override string IsValid(Card[] hand)
        {
            if ((!string.IsNullOrEmpty(flush.Validate(hand))) && (!string.IsNullOrEmpty(straight.Validate(hand))))
                return "You have a Straight Flush with " + string.Join(", ", hand.Select(x => x.ToString()));

            return string.Empty;
        }
    }
}
