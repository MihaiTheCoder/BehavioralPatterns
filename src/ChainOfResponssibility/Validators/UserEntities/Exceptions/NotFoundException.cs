using System;

namespace ChainOfResponssibility.Validators.UserEntities
{
    internal class NotFoundException : Exception
    {
        private int iD;

        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(int iD)
        {
            this.iD = iD;
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}