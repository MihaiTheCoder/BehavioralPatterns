using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.Validators
{
    public abstract class ChainValidation<T>
    {
        public ChainValidation<T> Successor { get; private set; }

        public ChainValidation<T> SetSuccessor(ChainValidation<T> successor)
        {
            return Successor = successor;
        }

        protected abstract ValidationResult IsValid(T obj);

        public ValidationResult Validate(T obj)
        {
            ValidationResult result = IsValid(obj);

            if (!result.IsValid)
                return result;

            if (Successor != null)
                return Successor.Validate(obj);
            else
                return result;

        }
    }
}
