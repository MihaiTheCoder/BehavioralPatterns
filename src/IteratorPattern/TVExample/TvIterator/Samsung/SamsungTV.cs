using IteratorPattern.TVExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteratorPattern.TvIterator
{
    /// <summary>
    /// Concrete implementation of Aggregate interface
    /// </summary>
    public class SamsungTV : TV
    {
        TVCableSupplier cableSupplier;
        public SamsungTV(TVCableSupplier cableSupplier)
        {
            this.cableSupplier = cableSupplier;
        }
        public ChannelIterator GetIterator()
        {
            return new SamsungChannelIterator(cableSupplier);
        }
    }
}
