using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IteratorPattern.FileExample
{
    public class LineReader : IEnumerable<string>
    {
        public string FilePath { get; private set; }
        public LineReader(string filePath)
        {
            FilePath = filePath;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<string> GetEnumerator()
        {
            using (TextReader reader = File.OpenText(FilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
    
}
