using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorPattern.StockExchange
{
    /// <summary>
    /// Mediator implementation
    /// </summary>
    public class StockExchange : IStockExchange
    {
        Dictionary<string, List<Trader>> sellers;
        Dictionary<string, List<Trader>> buyers;

        public StockExchange()
        {
            sellers = new Dictionary<string, List<Trader>>();
            buyers = new Dictionary<string, List<Trader>>();
            
        }
        protected void AddSeller(Trader trader)
        {
            AddTrader(trader, sellers);
        }

        protected void AddBuyer(Trader trader)
        {
            AddTrader(trader, buyers);
        }        

        public bool Buy(Trader trader, StockRequest request)
        {
            if (!sellers.ContainsKey(request.Symbol))
            {
                AddBuyer(trader);
                Console.WriteLine("There are no sellers for {0}", request.Symbol);
                return false;
            }

            List<Trader> sellersOfStock = sellers[request.Symbol];

            var couldBuyStocks = sellersOfStock.Any(s => s.AcceptSell(request));

            if (!couldBuyStocks)
            {
                AddBuyer(trader);
                Console.WriteLine("No one seller sells it at this price, try a higher price");
            }
            else
            {
                Console.WriteLine("Actions bought");
            }

            return couldBuyStocks;
        }

        public bool Sell(Trader trader, StockRequest request)
        {
            if (!buyers.ContainsKey(request.Symbol))
            {
                AddSeller(trader);
                Console.WriteLine("There are no buyers for {0}", request.Symbol);
                return false;
            }

            var couldSellStocks = buyers[request.Symbol].Any(b => b.AcceptBuy(request));

            if (!couldSellStocks)
            {
                AddSeller(trader);
                Console.WriteLine("No one seller buys it at this price, try a lower price");
            }
                

            return couldSellStocks;
        }

        private void AddTrader(Trader trader, Dictionary<string, List<Trader>> traderList)
        {
            if (!traderList.ContainsKey(trader.Symbol))
            {
                traderList.Add(trader.Symbol, new List<Trader> { trader });
            }
            else
            {
                traderList[trader.Symbol].Add(trader);
            }
        }
    }
}

