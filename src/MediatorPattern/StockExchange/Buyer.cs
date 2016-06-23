namespace MediatorPattern.StockExchange
{
    public class Buyer : Trader
    {
        IStockExchange stockExchange;
        public Buyer(string name, string symbol, int count, double price, IStockExchange stockExchange) : base(name, symbol, count, price)
        {
            this.stockExchange = stockExchange;            
        }

        public bool BuyFromStockExchange()
        {
            return stockExchange.Buy(this, new StockRequest { Count = Count, Price = Price, Symbol = Symbol, Requester = Name });
        }
    }
}
