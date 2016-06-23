using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.StockExchange
{
    public class Seller : Trader
    {
        IStockExchange stockExchange;
        public Seller(string name, string symbol, int count, double price, IStockExchange stockExchange) : base(name, symbol, count, price)
        {
            this.stockExchange = stockExchange;
        }

        public bool SellFromStockExchange()
        {
            return stockExchange.Sell(this, new StockRequest { Count = Count, Price = Price, Symbol = Symbol, Requester = Name });
        }
    }
}
