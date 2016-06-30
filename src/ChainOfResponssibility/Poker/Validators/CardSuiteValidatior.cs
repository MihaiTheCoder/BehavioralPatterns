using ChainOfResponssibility.Validators;
using System;
using System.Linq;

namespace ChainOfResponssibility.Poker.Validators
{
    public class CardSuiteValidation : ChainValidation<Card>
    {
        protected override ValidationResult IsValid(Card obj)
        {
            if (Card.ValidSuites.Contains(obj.Suite))
                return ValidationResult.GetValidResult();
            return ValidationResult.GetInvalidResult(new Exception("Invalid Suite, must be one of " + Card.ValidSuites));
        }
    }
}
