using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPattern.StocksExample.Commands
{
    public class SellStockOrder : Order
    {
        StocksAPI stocksAPI;
        Stock stock;
        public SellStockOrder(StocksAPI stocksAPI, Stock stock)
        {
            this.stocksAPI = stocksAPI;
            this.stock = stock;
        }

        public void Execute()
        {
            stocksAPI.Sell(stock);
        }
    }
}
