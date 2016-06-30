using ChainOfResponssibility.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.Poker.Validators
{
    public class CardValidationFactory
    {
        private static ChainValidation<Card> _validator;

        public static ChainValidation<Card> GetValidator()
        {
            if (_validator != null)
                return _validator;

            _validator = new CardSuiteValidation();
            _validator.SetSuccessor(new CardValueValidation());

            return _validator;
        }
    }
}
