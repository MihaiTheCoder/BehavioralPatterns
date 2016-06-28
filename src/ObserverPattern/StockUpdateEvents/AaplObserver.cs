using System;

namespace ObserverPattern.StockUpdateEvents
{
    /// <summary>
    /// Observer
    /// </summary>
    public class AaplObserver
    {
        double? oldValue;
        public AaplObserver(StockSubject stockObservable)
        {
            stockObservable.StockUpdated += (obj, e) => PrintNewValue(e.Stock);
        }

        private void PrintNewValue(Stock stock)
        {
            if (stock.Name == "AAPL")
            {
                if (oldValue.HasValue)
                    Console.WriteLine("Apple price updated from {0} to {1}", oldValue, stock.Value);
                else
                    Console.WriteLine("Apple has a new price, new value is: {0}", stock.Value);

                oldValue = stock.Value;
            }
        }
    }
}