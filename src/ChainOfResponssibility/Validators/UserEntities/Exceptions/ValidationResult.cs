using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.Validators
{
    public class ValidationResult
    {
        protected ValidationResult(bool isValid, Exception e)
        {
            IsValid = isValid;
            Exception = e;
        }

        public static ValidationResult GetValidResult()
        {
            return new ValidationResult(true, null);
        }

        public static ValidationResult GetInvalidResult(Exception e)
        {
            return new ValidationResult(false, e);
        }

        public Exception Exception { get; set; }

        public bool IsValid { get; set; }
    }

    public class ValidationResult<T> : ValidationResult
    {
        public ValidationResult(bool isValid, Exception e, T model) : base(isValid, e)
        {
        }

        public static ValidationResult<T> GetValidResult(T model)
        {
            return new ValidationResult<T>(true, null, model);
        }

        public static ValidationResult<T> GetInvalidResult(Exception e)
        {
            return new ValidationResult<T>(false, e, default(T));
        }

        public T Result { get; set; }
    }
}
