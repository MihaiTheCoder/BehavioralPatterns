namespace ChainOfResponssibility.Poker.Validators.HandValidators
{
    public abstract class HandValidation
    {
        public HandValidation Successor { get; private set; }

        public HandValidation SetSuccessor(HandValidation successor)
        {
            return Successor = successor;
        }

        protected abstract string IsValid(Card[] hand);

        public string Validate(Card[] hand)
        {
            string result = IsValid(hand);

            if (!string.IsNullOrWhiteSpace(result))
                return result;

            if (Successor != null)
                return Successor.Validate(hand);
            else
                return result;

        }
    }
}
