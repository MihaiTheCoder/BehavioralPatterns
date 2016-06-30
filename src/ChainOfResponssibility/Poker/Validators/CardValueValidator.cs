using ChainOfResponssibility.Validators;
using System;
using System.Linq;

namespace ChainOfResponssibility.Poker.Validators
{
    public class CardValueValidation : ChainValidation<Card>
    {
        protected override ValidationResult IsValid(Card obj)
        {
            if (Card.ValidValues.Contains(obj.Value))
                return ValidationResult.GetValidResult();
            return ValidationResult.GetInvalidResult(new Exception("Invalid Value, must be one of " + Card.ValidValues));
        }
    }
}
