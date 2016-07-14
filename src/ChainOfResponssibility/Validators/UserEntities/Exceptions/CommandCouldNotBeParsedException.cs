using System;

namespace ChainOfResponssibility.Validators.UserEntities
{
    internal class CommandCouldNotBeParsedException : Exception
    {
        public CommandCouldNotBeParsedException()
        {
        }

        public CommandCouldNotBeParsedException(string message) : base(message)
        {
        }

        public CommandCouldNotBeParsedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}