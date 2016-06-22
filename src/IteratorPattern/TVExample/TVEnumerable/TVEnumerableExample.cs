using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteratorPattern.TVExample.TVEnumerable
{
    public class TVEnumerableExample
    {
        public void Run()
        {
            IEnumerable<Channel> tv = new SamsungTV(new TVCableSupplier());
            foreach (var channel in tv)
            {
                Console.WriteLine(channel.Name);
            }
        }
    }
}
