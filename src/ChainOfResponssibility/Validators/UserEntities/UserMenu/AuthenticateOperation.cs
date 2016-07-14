using System;

namespace ChainOfResponssibility.Validators.UserEntities.UserMenu
{
    public class AuthenticateOperation : Operation
    {
        const string prefix = "authenticate as";
        Action<string> authenticateFunction;
        public AuthenticateOperation(Action<string> authenticateFunction)
        {
            this.authenticateFunction = authenticateFunction;
        }

        protected override bool CanExecute(string command)
        {            
            return command.ToLower().StartsWith(prefix);
        }

        protected override void ExecuteSpecificOperation(string command)
        {
            string email = command.Substring(prefix.Length + 1);
            authenticateFunction(email);
        }

        protected override string GetMessageToPrint()
        {
            return string.Format("To authenticate press: {0} <email>", prefix);
        }
    }
}
