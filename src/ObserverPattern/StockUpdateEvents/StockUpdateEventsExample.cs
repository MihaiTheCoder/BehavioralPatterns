using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
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

        public void RunReactiveWithEvents()
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

        public void RunReactive()
        {
            Subject<Stock> stockSubject = new Subject<Stock>();

            var londonObserver = stockSubject.Where(s => s.Name == "FTSE");
            var aaplObserver = stockSubject.Where(s => s.Name == "AAPL");

            using (londonObserver.Subscribe(PrintLondonStockPriceUpdate))
            using (aaplObserver.Subscribe(PrintAaplStockPriceUpdate))
            {
                PublishUpdateStocks(stockSubject);
            }
        }

        private void PrintAaplStockPriceUpdate(EventPattern<StockUpdateEventArgs> eventP)
        {
            PrintAaplStockPriceUpdate(eventP.EventArgs.Stock);
        }

        private void PrintAaplStockPriceUpdate(Stock stock)
        {
            Console.WriteLine("apple updated, new value: {0}", stock.Value);
        }

        private void PrintLondonStockPriceUpdate(EventPattern<StockUpdateEventArgs> eventP)
        {
            PrintLondonStockPriceUpdate(eventP.EventArgs.Stock);
        }

        private void PrintLondonStockPriceUpdate(Stock stock)
        {
            Console.WriteLine("london stock updated, new value: {0}", stock.Value);
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

        private static void PublishUpdateStocks(Subject<Stock> stockSubject)
        {
            stockSubject.OnNext(new Stock { Name = "AAPL", Value = 3 });
            stockSubject.OnNext(new Stock { Name = "AAPL", Value = 4 });
            stockSubject.OnNext(new Stock { Name = "AAPL", Value = 5 });
            stockSubject.OnNext(new Stock { Name = "AAPL", Value = 6 });

            stockSubject.OnNext(new Stock { Name = "FTSE", Value = 6 });
            stockSubject.OnNext(new Stock { Name = "FTSE", Value = 12 });
            stockSubject.OnNext(new Stock { Name = "FTSE", Value = 2 });
            stockSubject.OnNext(new Stock { Name = "FTSE", Value = 3 });
        }
    }
}
