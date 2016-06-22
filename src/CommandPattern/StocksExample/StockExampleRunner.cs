using CommandPattern.StocksExample.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPattern.StocksExample
{
    public class StockExampleRunner
    {
        public void Run()
        {
            StocksAPI stocksAPI = new StocksAPI();
            Agent agent = new Agent(new StockSchedule());

            Stock stock = new Stock { Name = "AAPL", Quantity = 20 };

            agent.PlaceOrder(new BuyStockOrder(stocksAPI, stock));
            agent.PlaceOrder(new SellStockOrder(stocksAPI, stock));
        }

        public string GetDescriptionOfExample()
        {
            return @"
Buy or sell a stock on the market. 
If the market is closed save the orders for when the market opens again.
When the market opens place all the orders.";
        }
    }
}
