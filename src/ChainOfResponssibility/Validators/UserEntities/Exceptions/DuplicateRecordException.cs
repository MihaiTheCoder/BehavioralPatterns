using System;

namespace ChainOfResponssibility.Validators.UserEntities
{
    internal class DuplicateRecordException : Exception
    {
        public DuplicateRecordException()
        {
        }

        public DuplicateRecordException(string message) : base(message)
        {
        }

        public DuplicateRecordException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}