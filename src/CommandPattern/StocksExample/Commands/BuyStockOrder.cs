using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPattern.StocksExample.Commands
{
    //Concrete Command
    public class BuyStockOrder : Order
    {
        StocksAPI stocksAPI;
        Stock stock;
        public BuyStockOrder(StocksAPI stocksAPI, Stock stock)
        {
            this.stocksAPI = stocksAPI;
            this.stock = stock;
        }

        public void Execute()
        {
            stocksAPI.Buy(stock);
        }
    }
}
