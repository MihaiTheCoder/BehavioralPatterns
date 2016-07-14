using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.TransferFileExample
{
    public abstract class TransferClient
    {
        protected abstract bool CanTransferTo(string destination);

        protected abstract void Transfer(string source, string destination);

        protected TransferClient Successor { get; private set; }

        public void TransferFile(string source, string destination)
        {
            if(CanTransferTo(destination))
            {
                Transfer(source, destination);
            }
            else
            {
                if (Successor != null)
                    Successor.TransferFile(source, destination);
                else
                    Console.WriteLine("Could not transfer file to: {0}", destination);
            }
        }

        public TransferClient SetSuccessor(TransferClient successor)
        {
            return Successor = successor;
        }
    }
}
