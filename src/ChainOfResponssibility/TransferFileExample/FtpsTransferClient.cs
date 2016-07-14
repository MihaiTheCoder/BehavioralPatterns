using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.TransferFileExample
{
    public class SftpransferClient : TransferClient
    {
        protected override bool CanTransferTo(string destination)
        {
            return destination.StartsWith("sftp:");
        }

        protected override void Transfer(string source, string destination)
        {
            Console.WriteLine("SFTP transfer file from: {0} to {1}", source, destination);
        }
    }
}
