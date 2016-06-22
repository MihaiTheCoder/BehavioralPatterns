using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IteratorPattern.FileExample
{
    public class ReadBigFilesExample
    {
        public void Run()
        {
            string[] files = Directory.GetFiles("bin/Debug/IteratorPattern/FileExample/SampleFiles");
            var filesWithContent = from file in files
                                   where HasAnyLines(file)
                                   select file;

            foreach (var fileWithContent in filesWithContent)
            {
                Console.WriteLine("File with content: {0}", fileWithContent);
            }
                        
        }

        private bool HasAnyLines(string file)
        {
            return new LineReader(file).Any();
        }
    }
}
