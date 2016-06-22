using IteratorPattern.TVExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteratorPattern.TvIterator
{
    public class TVIteratorExample
    {
        public void Run()
        {
            TV tv = new SamsungTV(new TVCableSupplier());
            ChannelIterator iterator = tv.GetIterator();

            do
            {
                Console.WriteLine("Current channel is: " + iterator.Current.Name);
                iterator.MoveNext();

            } while (iterator.HasNext());
        }
    }
}
