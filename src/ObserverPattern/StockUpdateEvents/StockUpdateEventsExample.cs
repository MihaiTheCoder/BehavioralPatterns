using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace ObserverPattern.StockUpdateEvents
{
    public class StockUpdateEventsExample
    {
        public void RunSimple()
        {
            StockSubject stockSubject = new StockSubject();

            LondonStockObserver londonObserver = new LondonStockObserver(stockSubject);

            AaplObserver aaplObserver = new AaplObserver(stockSubject);

            PublishUpdateStocks(stockSubject);
        }        

        public void RunReactive()
        {
            StockSubject stockSubject = new StockSubject();

            var londonObserver = Observable.FromEventPattern<StockUpdateEventArgs>(
                ev => stockSubject.StockUpdated += ev,
                ev => stockSubject.StockUpdated -= ev).Where(s => s.EventArgs.Stock.Name == "FTSE");

            var aaplObserver = Observable.FromEventPattern<StockUpdateEventArgs>(
                ev => stockSubject.StockUpdated += ev,
                ev => stockSubject.StockUpdated -= ev).Where(s => s.EventArgs.Stock.Name == "AAPL");

            using (londonObserver.Subscribe(PrintLondonStockPriceUpdate))
            using (aaplObserver.Subscribe(PrintAaplStockPriceUpdate))
            {
                PublishUpdateStocks(stockSubject);
            }
        }

        private void PrintAaplStockPriceUpdate(EventPattern<StockUpdateEventArgs> eventP)
        {
            Console.WriteLine("apple updated, new value: {0}", eventP.EventArgs.Stock.Value);
        }

        private void PrintLondonStockPriceUpdate(EventPattern<StockUpdateEventArgs> eventP)
        {
            Console.WriteLine("london stock updated, new value: {0}", eventP.EventArgs.Stock.Value);
        }

        private static void PublishUpdateStocks(StockSubject stockSubject)
        {
            stockSubject.UpdateStockValue(new Stock { Name = "AAPL", Value = 3 });
            stockSubject.UpdateStockValue(new Stock { Name = "AAPL", Value = 4 });
            stockSubject.UpdateStockValue(new Stock { Name = "AAPL", Value = 5 });
            stockSubject.UpdateStockValue(new Stock { Name = "AAPL", Value = 6 });

            stockSubject.UpdateStockValue(new Stock { Name = "FTSE", Value = 6 });
            stockSubject.UpdateStockValue(new Stock { Name = "FTSE", Value = 12 });
            stockSubject.UpdateStockValue(new Stock { Name = "FTSE", Value = 2 });
            stockSubject.UpdateStockValue(new Stock { Name = "FTSE", Value = 3 });
        }
    }
}
