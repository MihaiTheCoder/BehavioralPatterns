using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChainOfResponssibility.TransferFileExample
{
    public class TransferFilesManager
    {
        TransferClient tranferClient;        

        public TransferFilesManager()
        {
            tranferClient = new FtpTransferClient();
            tranferClient
                .SetSuccessor(new HttpTransferClient())
                .SetSuccessor(new SftpransferClient())
                .SetSuccessor(new FileCopyClient());
        }

        public void TransferFiles()
        {
            string src = "", dst = "";

            do
            {
                Console.WriteLine("Source:");
                Console.Write(">");
                src = Console.ReadLine();
                Console.WriteLine("Destination:");
                Console.Write(">");
                dst = Console.ReadLine();

                if (!IsExitCode(src) && !IsExitCode(dst))
                    tranferClient.TransferFile(src, dst);

            } while (!IsExitCode(src) && !IsExitCode(dst));
        }

        private static bool IsExitCode(string input)
        {
            return "exit".Equals(input, StringComparison.OrdinalIgnoreCase);
        }

        public string GetDescriptionOfExample()
        {
            return @"Description of example:
TransferFilesManager will try to transfer the file to the destination by trying FTP, SFTP, Http, and simple file copy";
        }
    }
}
