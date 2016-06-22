using IteratorPattern.TVExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteratorPattern.TvIterator
{
    /// <summary>
    /// Iterator interface
    /// The Iterator defines the interface for access and traversal of the elements
    /// </summary>
    public interface ChannelIterator
    {
        bool HasNext();

        Channel Current { get; }

        Channel MoveNext();
    }
}
