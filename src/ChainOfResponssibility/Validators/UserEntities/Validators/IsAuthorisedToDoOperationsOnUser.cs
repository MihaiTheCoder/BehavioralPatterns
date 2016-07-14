using ChainOfResponssibility.Validators.UserEntities.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.Validators.UserEntities.Validators
{
    public class IsAuthorisedToDoOperationsOnUser : ChainValidation<User>
    {
        PrincipalHelper principalHelper;
        Rights rights;
        public IsAuthorisedToDoOperationsOnUser(PrincipalHelper principalHelper, Rights rights)
        {
            this.principalHelper = principalHelper;
            this.rights = rights;
        }

        protected override ValidationResult IsValid(User obj)
        {
            User authenticatedUser = principalHelper.GetAuthenticatedUser();

            if (authenticatedUser == null)
                return ValidationResult.GetInvalidResult(new ForbiddenException("Only authenticated users may create new users"));
            
            if (!authenticatedUser.Rights.HasFlag(rights))
                return ValidationResult.GetInvalidResult(new ForbiddenException(string.Format("Unauthorised to do {0} on user", rights)));

            if (authenticatedUser.TenantId != obj.TenantId)
                return ValidationResult.GetInvalidResult(new ForbiddenException("Cannot create user for another tenant"));

            return ValidationResult.GetValidResult();
        }
    }
}
