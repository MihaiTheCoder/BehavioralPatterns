using ChainOfResponssibility.Validators.UserEntities.Infrastructure;
using ChainOfResponssibility.Validators.UserEntities.UserMenu;
using ChainOfResponssibility.Validators.UserEntities.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.Validators.UserEntities
{
    public class UserProcessor
    {
        UserRepository userRepository;
        PrincipalHelper principalHelper;
        Operation operation;
        ChainValidation<User> userCreationValidation;
        ChainValidation<User> authenticateUserValidation;
        public UserProcessor()
        {
            userRepository = new UserRepository();
            principalHelper = new PrincipalHelper();
            operation = new AuthenticateOperation(AuthenticateUser);
            operation.SetSuccessor(new CreateNewUserOperation(CreateNewUser));

            userCreationValidation = new IsAuthorisedToDoOperationsOnUser(principalHelper, Rights.Create);
            userCreationValidation.SetSuccessor(new ValidateNoDuplicateEmail(userRepository));

            authenticateUserValidation = new ValidateUserExistsInDb(userRepository);

        }

        private void CreateNewUser(string email, string userName, int tenantId)
        {
            User user = new User { Email = email, UserName = userName, TenantId = tenantId };
            var result = userCreationValidation.Validate(user);

            if (result.IsValid)
                userRepository.Add(user);
            else
                Console.WriteLine(result.Exception);
        }

        private void AuthenticateUser(string email)
        {
            var result = authenticateUserValidation.Validate(new User { Email = email });

            if (result.IsValid)
            { 
                principalHelper.SetAuthenticatedUser(userRepository.Get(email));
                Console.WriteLine("Authentication successful");
            }
            else
                Console.WriteLine(result.Exception.Message);
        }

        public void DoStuff()
        {
            string userInput;
            do
            {
                operation.PrintMenu();
                Console.Write(">");
                userInput = Console.ReadLine();

                if (!IsExitCode(userInput))
                    operation.Execute(userInput);

            } while (!IsExitCode(userInput));
        }

        private static bool IsExitCode(string input)
        {
            return "exit".Equals(input, StringComparison.OrdinalIgnoreCase);
        }
    }
}
