using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteratorPattern.TvIterator
{
    /// <summary>
    /// Aggregate interface - get iterator
    /// The Aggregate defines an interface for the creation of the Iterator object.
    /// </summary>
    public interface TV
    {
        ChannelIterator GetIterator();
    }
}
