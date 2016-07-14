using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.Validators.UserEntities
{
    public class ValidateUserExistsInDb : ChainValidation<User>
    {
        UserRepository userRepository;
        public ValidateUserExistsInDb(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        protected override ValidationResult IsValid(User obj)
        {
            bool userExists = userRepository.Exists(obj.Email);

            if (userExists)
                return ValidationResult.GetValidResult();
            else
                return ValidationResult.GetInvalidResult(new NotFoundException(obj.ID));

        }
    }
}
