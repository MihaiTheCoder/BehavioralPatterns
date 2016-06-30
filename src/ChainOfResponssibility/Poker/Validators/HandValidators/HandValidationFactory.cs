namespace ChainOfResponssibility.Poker.Validators.HandValidators
{
    public class HandValidationFactory
    {
        private static HandValidation _cachedValidation;

        public static HandValidation GetValidation()
        {
            if (_cachedValidation != null)
                return _cachedValidation;

            var royalflush = new RoyalFlushValidation();

            var straightflush = new StraightFlushValidation();
            royalflush.SetSuccessor(straightflush);

            var fourofakind = new FourOfAKindValidation();
            straightflush.SetSuccessor(fourofakind);

            var fullhouse = new FullHouseValidation();
            fourofakind.SetSuccessor(fullhouse);

            var flush = new FlushValidation();
            fullhouse.SetSuccessor(flush);

            var straight = new StraightValidation();
            flush.SetSuccessor(straight);

            var threeofakind = new ThreeOfAKindValidation();
            straight.SetSuccessor(threeofakind);

            var twopairs = new TwoPairsValidation();
            threeofakind.SetSuccessor(twopairs);

            var pairs = new PairValidation();
            twopairs.SetSuccessor(pairs);

            var high = new HighCardValidation();
            pairs.SetSuccessor(high);

            _cachedValidation = royalflush;
            return _cachedValidation;
        }
    }
}
