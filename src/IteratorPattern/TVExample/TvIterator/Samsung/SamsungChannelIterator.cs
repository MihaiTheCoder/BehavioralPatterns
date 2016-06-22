using IteratorPattern.TVExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteratorPattern.TvIterator
{
    /// <summary>
    /// Concrete implementation of Iterator interface
    /// </summary>
    public class SamsungChannelIterator : ChannelIterator
    {
        int currentPos;
        TVCableSupplier cableSupplier;
        public SamsungChannelIterator(TVCableSupplier cableSupplier)
        {
            currentPos = 0;
            this.cableSupplier = cableSupplier;
        }
        public Channel Current
        {
            get
            {
                return cableSupplier.Channels[currentPos];
            }
        }

        public bool HasNext()
        {
            return currentPos < cableSupplier.Channels.Count;

        }

        public Channel MoveNext()
        {
            return cableSupplier.Channels[currentPos++];
        }
    }
}
