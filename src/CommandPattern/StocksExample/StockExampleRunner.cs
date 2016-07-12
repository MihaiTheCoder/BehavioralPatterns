using CommandPattern.StocksExample.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPattern.StocksExample
{
    /// <summary>
    /// Client
    /// </summary>
    public class StockExampleRunner
    {
        public void RunWithRealStockSchedule()
        {
            Console.WriteLine("Buy/Sell stock with real stock schedule");
            
            Agent agent = new Agent(new StockSchedule());

            BuyAndSellApplStock(agent);
        }

        public void RunWithMarketClosed()
        {
            Console.WriteLine("Buy/Sell stock when the market is closed, and not opening soon");

            Agent agent = new Agent(new FakeStockSchedule(false, TimeSpan.FromHours(10)));

            BuyAndSellApplStock(agent);
        }                

        public void RunWithMarketOpened()
        {
            Console.WriteLine("Buy/Sell stock when the market is opened");

            Agent agent = new Agent(new FakeStockSchedule(true, TimeSpan.FromHours(10)));

            BuyAndSellApplStock(agent);
        }

        public void RunWithMarketOpeningInTwoSeconds()
        {
            Console.WriteLine("Buy/Sell stock when the market is closed, but opening in 2 seconds");

            Agent agent = new Agent(new FakeStockSchedule(false, TimeSpan.FromSeconds(2)));

            BuyAndSellApplStock(agent);
        }

        private static void BuyAndSellApplStock(Agent agent)
        {
            StocksAPI stocksAPI = new StocksAPI();
            Stock stock = new Stock { Name = "AAPL", Quantity = 20 };

            agent.PlaceOrder(new BuyStockOrder(stocksAPI, stock));
            agent.PlaceOrder(new SellStockOrder(stocksAPI, stock));
        }

        public string GetDescriptionOfExample()
        {
            return @"Example description:
Buy or sell a stock on the market. 
If the market is closed save the orders for when the market opens again.
When the market opens place all the orders.";
        }
    }
}
