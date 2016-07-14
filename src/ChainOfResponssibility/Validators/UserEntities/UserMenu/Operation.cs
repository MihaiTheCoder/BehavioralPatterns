using System;

namespace ChainOfResponssibility.Validators.UserEntities.UserMenu
{
    public abstract class Operation
    {
        protected abstract bool CanExecute(string command);

        protected abstract void ExecuteSpecificOperation(string command);

        protected abstract string GetMessageToPrint();

        public Operation Successor { get; private set; }

        public Operation SetSuccessor(Operation successor)
        {
            return Successor = successor;
        }

        public ValidationResult Execute(string command)
        {
            if (CanExecute(command))
            {
                ExecuteSpecificOperation(command);
                return ValidationResult.GetValidResult();
            }
            else
            {
                if (Successor != null)
                    return Successor.Execute(command);
                else
                    return GetInvalidResult(command);
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine(GetMessageToPrint());

            if (Successor != null)
                Successor.PrintMenu();
        }

        private static ValidationResult GetInvalidResult(string command)
        {
            return ValidationResult.GetInvalidResult(new CommandCouldNotBeParsedException(command));
        }
    }
}
