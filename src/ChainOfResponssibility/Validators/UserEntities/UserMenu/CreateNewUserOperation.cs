using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.Validators.UserEntities.UserMenu
{
    public class CreateNewUserOperation : Operation
    {
        string prefix = "create user";
        Action<string, string, int> createUser;
        public CreateNewUserOperation(Action<string, string, int> createUser)
        {
            this.createUser = createUser;
        }

        protected override bool CanExecute(string command)
        {
            var hasCorrectPrefix = command.ToLower().StartsWith(prefix) && command.Contains(",");
            return hasCorrectPrefix && IsInt(GetTenantId(command));
        }

        protected override void ExecuteSpecificOperation(string command)
        {
            string commandWithoutPrefix = command.Substring(prefix.Length);

            string email = new string(commandWithoutPrefix.TakeWhile(c => c != ',').Skip(1).ToArray()).Trim();

            string userName = GetUserName(commandWithoutPrefix);

            int tenantId = int.Parse(GetTenantId(commandWithoutPrefix));
            createUser(email, userName, tenantId);
        }

        public static string GetUserName(string command)
        {
            string commandWithoutEmail = command.Substring(command.IndexOf(',') + 1);
            string userName = commandWithoutEmail.Substring(0, commandWithoutEmail.LastIndexOf(','));
            return userName.Trim();
        }

        private static string GetTenantId(string command)
        {
            return command.Substring(command.LastIndexOf(',') + 1).Trim();
        }

        protected override string GetMessageToPrint()
        {
            return string.Format("To create a new user press: create user <email>, <username>, <tenant id>");
        }

        private bool IsInt(string tenantId)
        {
            int number;
            return int.TryParse(tenantId, out number);
        }
    }
}
