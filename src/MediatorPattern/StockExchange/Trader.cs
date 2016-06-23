using System;

namespace MediatorPattern.StockExchange
{
    /// <summary>
    /// Colleague
    /// </summary>
    public class Trader
    {
        public string Name { get; private set; }
        public Trader(string name, string symbol, int count, double price)
        {
            Name = name;
            Symbol = symbol;
            Count = count;
            Price = price;
        }
        public string Symbol { get; private set; }

        public int Count { get; private set; }

        public double Price { get; private set; }

        public virtual bool AcceptSell(StockRequest request)
        {
            if(request.Price >= Price)
            {
                Console.WriteLine("{0} will sell {1} actions of {2} at the price of {3} to {4}",
                    Name, request.Count, request.Symbol, request.Price, request.Requester);
                return true;
            }
            return false;
        }

        public virtual bool AcceptBuy(StockRequest request)
        {
            if(request.Price <= Price)
            {
                Console.WriteLine("{0} will buy {1} actions of {2} at the price of {3} from {4}",
                    Name, request.Count, request.Symbol, request.Price, request.Requester);
                return true;
            }

            return false;
        }
    }
}