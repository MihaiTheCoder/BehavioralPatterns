using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPattern.StocksExample
{
    /// <summary>
    /// Command interface
    /// </summary>
    public interface Order
    {
        void Execute();
    }
}
