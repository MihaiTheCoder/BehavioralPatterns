using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteratorPattern.TVExample.TVEnumerable
{
    public class SamsungChannelIterator : IEnumerator<Channel>
    {
        int currPos;
        TVCableSupplier cableSupplier;
        public SamsungChannelIterator(TVCableSupplier cableSupplier)
        {
            this.cableSupplier = cableSupplier;
            currPos = -1;
        }

        public Channel Current { get { return cableSupplier.Channels[currPos]; } }

        object IEnumerator.Current { get { return cableSupplier.Channels[currPos]; } }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if(currPos < cableSupplier.Channels.Count -1)
            {
                currPos++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            currPos = -1;
        }
    }
}
