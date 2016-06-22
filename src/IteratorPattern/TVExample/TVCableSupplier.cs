using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteratorPattern.TVExample
{
    public class TVCableSupplier
    {
        public TVCableSupplier()
        {
            Channels = new List<Channel> {
                new Channel { Name = "DIGI24"},
                new Channel { Name = "Acasa TV"},
                new Channel { Name = "Taraf"},
                new Channel { Name = "Manele TV"}
            };
        }

        public List<Channel> Channels { get; private set; }
    }
}
