using System;

namespace ObserverPattern.StockUpdateEvents
{
    public class LondonStockObserver
    {
        double? oldValue;
        public LondonStockObserver(StockSubject stockObservable)
        {
            stockObservable.StockUpdated += (obj, e) => PrintStockValue(e.Stock);
        }

        private void PrintStockValue(Stock stock)
        {
            if (stock.Name == "FTSE")
            {
                if (oldValue.HasValue)
                    Console.WriteLine("The Financial Times Stock Exchange 100 Index price updated from {0} to {1}", oldValue, stock.Value);
                else
                    Console.WriteLine("The Financial Times Stock Exchange 100 Index has a new price, new value is: {0}", stock.Value);
                oldValue = stock.Value;
            }
        }
    }
}