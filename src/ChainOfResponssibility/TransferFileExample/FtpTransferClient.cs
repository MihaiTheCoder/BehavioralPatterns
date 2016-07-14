using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.TransferFileExample
{
    public class FtpTransferClient : TransferClient
    {
        protected override bool CanTransferTo(string destination)
        {
            return destination.StartsWith("ftp:");
        }

        protected override void Transfer(string source, string destination)
        {
            Console.WriteLine("FTP transfer file from: {0} to {1}", source, destination);
        }
    }
}
