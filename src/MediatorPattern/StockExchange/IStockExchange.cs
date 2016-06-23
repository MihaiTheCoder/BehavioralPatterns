using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.StockExchange
{
    /// <summary>
    /// Mediator
    /// </summary>
    public interface IStockExchange
    {
        bool Buy(Trader trader, StockRequest request);

        bool Sell(Trader trader, StockRequest request);
    }    
}
