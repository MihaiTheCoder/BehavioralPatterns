using System;
using System.IO;

namespace ChainOfResponssibility.TransferFileExample
{
    public class FileCopyClient : TransferClient
    {
        protected override bool CanTransferTo(string destination)
        {
            return destination.StartsWith("file://") || Directory.Exists(Path.GetDirectoryName(destination));
        }

        protected override void Transfer(string source, string destination)
        {
            Console.WriteLine("File copy from: {0} to {1}", source, destination);
        }
    }
}