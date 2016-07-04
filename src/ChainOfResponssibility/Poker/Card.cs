using System;
using ChainOfResponssibility.Validators;
using ChainOfResponssibility.Poker.Validators;

namespace ChainOfResponssibility.Poker
{
    public class Card
    {
        public const string ValidValues = "2,3,4,5,6,7,8,9,10,J,Q,K,A";
        public const string ValidSuites = "C,H,S,D";

        public string Value { get; private set; }
        public char Suite { get; private set; }
        public static ChainValidation<Card> CardValidatorFactory { get; private set; }

        public Card(string value, char suite)
        {
            Value = value.ToUpper();
            Suite = suite.ToString().ToUpper()[0];
        }

        public static Card Parse(string toParse)
        {
            Card c = null;
            switch (toParse.Length)
            {
                case 2:
                    c = new Card(toParse[0].ToString(), toParse[1]);
                    break;
                case 3:
                    c = new Card(toParse.Substring(0, 2), toParse[2]);
                    break;
                default:
                    throw new ArgumentException(string.Format("Must be in format VS where V is one of [{0}] and S is one of [{1}]", ValidValues, ValidSuites), nameof(toParse));
            }

            ChainValidation<Card> Validation = CardValidationFactory.GetValidator();

            var validationResult = Validation.Validate(c);

            if (!validationResult.IsValid)
                throw validationResult.Exception;

            return c;
        }

        public int GetIntValue()
        {
            int val = 0;
            if (int.TryParse(Value, out val))
                return val;
            else
                switch (Value)
                {
                    case "J":
                        return 11;
                    case "Q":
                        return 12;
                    case "K":
                        return 13;
                    case "A":
                        return 14;
                }
            return 0;
        }

        public override string ToString()
        {
            return Value + Suite;
        }
    }
}
