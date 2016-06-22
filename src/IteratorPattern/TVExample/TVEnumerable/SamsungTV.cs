using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteratorPattern.TVExample.TVEnumerable
{
    public class SamsungTV : IEnumerable<Channel>
    {
        TVCableSupplier cableSupplier;
        public SamsungTV(TVCableSupplier cableSupplier)
        {
            this.cableSupplier = cableSupplier;
        }

        public IEnumerator<Channel> GetEnumerator()
        {
            return new SamsungChannelIterator(cableSupplier);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SamsungChannelIterator(cableSupplier);
        }
    }
}
