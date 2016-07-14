using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.Validators.UserEntities
{
    public class ValidateNoDuplicateEmail : ChainValidation<User>
    {
        UserRepository userRepository;
        public ValidateNoDuplicateEmail(UserRepository userRepository)
        {
            this.userRepository = userRepository;

        }
        protected override ValidationResult IsValid(User obj)
        {
            if (userRepository.Exists(obj.Email))
                return ValidationResult.GetInvalidResult(new DuplicateRecordException(obj.Email));
            else
                return ValidationResult.GetValidResult();
        }
    }
}
